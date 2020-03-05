using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Training.DTO
{
    public class UserAuthorization: UserCredentials
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
    }
}
