using System.Text.Json.Serialization;

namespace CA.DAL.Models.Common
{
    public class ReturnViewModel
    {
        [JsonPropertyName("returnCode")]
        public int ReturnCode { get; set; }
        [JsonPropertyName("returnMessage")]
        public string ReturnMessage { get; set; }
        [JsonPropertyName("returnParam")]
        public List<string>? ReturnParameter { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }
        [JsonPropertyName("data")]
        public object? Data { get; set; }
        [JsonPropertyName("pageInfo")]
        public PaginationInfo? PaginationInfo { get; set; }
        [JsonPropertyName("server")]
        public string Server { get; set; } = Environment.MachineName;

        public ReturnViewModel()
        {
            ReturnCode = 200;
            ReturnMessage = "";
            ReturnParameter = new List<string>();
            Status = "OK";
            DateTime = DateTime.Now;
            Data = "";
            PaginationInfo = new PaginationInfo();
            Server = Environment.MachineName;
        }

        public ReturnViewModel(int returnCode, string returnMessage, string status, DateTime dateTime, object result, PaginationInfo? paginationInfo = null, List<string>? returnParameter = null)
        {
            ReturnCode = returnCode;
            ReturnMessage = returnMessage;
            Status = status;
            DateTime = dateTime;
            Data = result;
            PaginationInfo = paginationInfo;
            ReturnParameter = returnParameter;
        }
    }
}
