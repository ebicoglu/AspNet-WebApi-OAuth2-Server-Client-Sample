namespace Client
{
    public class TokenResult
    {
        public string AccessToken { get; set; }

        public string TokenType { get; set; }

        public int ExpiresIn { get; set; }

        public System.TimeSpan ExpireTime => System.TimeSpan.FromSeconds(ExpiresIn);
    }
}