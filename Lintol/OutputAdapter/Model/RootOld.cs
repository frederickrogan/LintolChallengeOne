using Newtonsoft.Json;

namespace Lintol.OutputAdapter.Model
{
    public class RootOld
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("item-count")]
        public long ItemCount { get; set; }

        [JsonProperty("issue-count")]
        public long IssueCount { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("info")]
        public InfoWarningError[] Info { get; set; }

        [JsonProperty("warnings")]
        public InfoWarningError[] Warnings { get; set; }

        [JsonProperty("errors")]
        public InfoWarningError[] Errors { get; set; }

        [JsonProperty("supplementary")]
        public Supplementary[] Supplementary { get; set; }
    }

    public class Supplementary
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    
}