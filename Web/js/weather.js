
var currentCityId = 3433955;


function GetDefaultWeather()
{
    GetWeather(currentCityId);
}

function OnMetricSystemChanged()
{
    GetWeather(currentCityId);
}

async function GetWeather(cityId)
{
    currentCityId = cityId;
    let metric_system = document.getElementById("inlineRadio1").checked ? "metric" : "imperial";
    let url = "http://localhost:5080/api/weatherforecast/weather/"+ cityId + "/" + metric_system;
    let response = await fetchAsync(url);
    if(response.status == 200)
    {
        let data = await response.json();
        SetData(data, metric_system);
    }
}   

function SetData(data, metric_system)
{
    let metric_system_text =  metric_system == "metric" ? "°C" : "°F";
    let cityText =  data.name + " ," + data.sys.country;
    let currentTemperatureText = "CurrentTemperature: <strong>" + data.main.temp + " " + metric_system_text + " </strong>";
    let feelsLikeText = "Feels like: <strong>"+ data.main.feels_like  + " " + metric_system_text + "</strong>";
    let minMaxText = "Max: <strong>"+ data.main.temp_max + " " + metric_system_text + "</strong>, Min: <strong>" + data.main.temp_min + " " + metric_system_text + "</strong>"
    SetText("City", cityText);
    SetText("CurrentTemperature", currentTemperatureText);
    SetText("FeelsLike", feelsLikeText);
    SetText("MinMax", minMaxText);
    SetText("Description", data.weather[0].description);
    document.getElementById("CurrentWeatherStatusIcon").className = "fas "+ data.weather[0].icon +" fa-3x"

    DrawForeCastWeather(data,metric_system_text);
}

function DrawForeCastWeather(data,metric_system_text)
{
    let forecastWeatherContainerId = document.getElementById("foreCastWeatherContainer");
    forecastWeatherContainerId.innerHTML = "";
    data.forecastWeatherList.forEach(element => {
       let item = "<div class=\"flex-column\">\
       <p class=\"small\"><strong> "+ element.main.temp + " " + metric_system_text +"</strong></p>\
       <i class=\"fas " + element.weather[0].icon  +" fa-2x mb-3\" style=\"color: #ddd;\"></i>\
       <p class=\"mb-0\"><strong>"+ element.dayofweek +"</strong></p>\
        </div>"
        forecastWeatherContainerId.innerHTML += item;
    });
        /*        */
}

async function fetchAsync (url) {
    return await fetch(url);
}



function SetText(textId, value)
{
    var element = document.getElementById(textId);
    if(element != null)
    {
        element.innerHTML = value;
    }
}