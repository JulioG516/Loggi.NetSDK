using System;
using System.Text.Json.Serialization;

namespace Loggi.NetSDK.Models.Labels
{
    public interface ILabelResponseType
    {
        [JsonPropertyName("createdTime")] public DateTime? CreatedTime { get; set; }
    }

    public class LabelResponseType : ILabelResponseType
    {
        [JsonPropertyName("createdTime")] public DateTime? CreatedTime { get; set; }
    }


    public class LabelResponseBase64 : LabelResponseType
    {
        [JsonPropertyName("content")] public string Content { get; set; }
    }

    public class LabelResponseUrl : LabelResponseType
    {
        [JsonPropertyName("url")] public string Url { get; set; }
    }
}