using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lintol.OutputAdapter.Model
{
    // so my data components seem like info
    // I think the processor is a constant for my project
    // code would by the component type
    // descriptive message for each code needed?
    // item would be the the location and word itself?
    // no context needed for components
    // probably no error data needed

    // first name surname pair would go to warning
    // With code and message
    // item could be the pair
    // context could be the components

    public class InfoWarningError
    {
        [JsonProperty("processor")]
        public string Processor { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("item")]
        public Context Item { get; set; }

        [JsonProperty("context")]
        public Context[] Context { get; set; }

        [JsonProperty("error-data")]
        public Attributes ErrorData { get; set; }
    }

    public class Context
    {
        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("location")]
        public Attributes Location { get; set; }

        [JsonProperty("definition")]
        public object[] Definition { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
    }

    
}
