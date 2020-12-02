using System.Text.Json.Serialization;

namespace Assignment1.Data
{
    public class User
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; }
        [JsonPropertyName("securityLevel")]
        public int Securitylevel { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        
    }
}