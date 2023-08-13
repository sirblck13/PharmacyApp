using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApi.Responses
{
    // NOTE: This class is currently used by the Partner API, which is consumed by external organizations.
    //       Before making changes, ensure we don't break compatibility with them.

    [DataContract(Name = "response")]
    public class ApiResponse<T> where T : class
    {
        /// <summary>
        /// Return object
        /// </summary>
        [DataMember]
        [Display(Name = "result")]
        [JsonProperty(PropertyName = "result")]
        [JsonPropertyName("result")]
        public T Result { get; set; }
        /// <summary>
        /// Message regarding status of operation
        /// </summary>
        [DataMember]
        [Display(Name = "error_message")]
        [JsonProperty(PropertyName = "error_message")]
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }
        /// <summary>
        /// HTTP response status
        /// </summary>
        [DataMember]
        [Display(Name = "status_code")]
        [JsonProperty(PropertyName = "status_code")]
        [JsonPropertyName("status_code")]
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// Whether response succeeded
        /// </summary>
        [DataMember]
        [Display(Name = "success")]
        [JsonProperty(PropertyName = "success")]
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        /// <summary>
        /// Operation timestamp
        /// </summary>
        [DataMember]
        [Display(Name = "timestamp")]
        [JsonProperty(PropertyName = "timestamp")]
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        public static ApiResponse<T> CreateOkResponse(T result)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Success = true,
                ErrorMessage = "",
                Timestamp = DateTime.UtcNow,
                Result = result
            };
        }

        public static ApiResponse<T> CreateBadRequestResponse(string errorMessage)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Success = false,
                ErrorMessage = errorMessage,
                Timestamp = DateTime.UtcNow,
            };
        }

        public static ApiResponse<T> CreateInternalServerErrorResponse(string errorMessage)
        {
            return new ApiResponse<T>()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Success = false,
                ErrorMessage = errorMessage,
                Timestamp = DateTime.UtcNow,
            };
        }

        public static ApiResponse<T> CreateResponse(HttpStatusCode statusCode, bool success, string errorMessage)
        {
            return new ApiResponse<T>()
            {
                StatusCode = statusCode,
                Success = success,
                ErrorMessage = errorMessage,
                Timestamp = DateTime.UtcNow,
            };
        }

    }
}
