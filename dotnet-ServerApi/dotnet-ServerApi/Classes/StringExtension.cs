namespace dotnet_ServerApi.Classes
{
    public static class StringExtension
    {
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            List<string> _listWords = new List<string>();
            var _words = str.Split(' ');        
            foreach(var word in _words)
            {
                _listWords.Add(char.ToUpper(word[0]) + word.Substring(1).ToLower());
            }
            return string.Join(" ", _listWords);
        }
    }
}
