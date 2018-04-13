using Newtonsoft.Json;

namespace Lintol.OutputAdapter.Model
{
    public class Root
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("item-count")]
        public long ItemCount { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("errors")]
        public Error[] Errors { get; set; }

        [JsonProperty("information")]
        public Information[] Info { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }
    }

    public class Information
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }
    }

    public class Item
    {
        [JsonProperty("itemType")]
        public string ItemType { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty("column")]
        public long Column { get; set; }

        [JsonProperty("row")]
        public long Row { get; set; }
    }
}