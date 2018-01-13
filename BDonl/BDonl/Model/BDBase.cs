using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System;

namespace BDonl.Model
{
    public class BDBase : IRegra
    {
        [JsonProperty("id")]
        public string Id { get ; set ; }

        [Version]
        public string Version { get ; set ; }
    }
}
