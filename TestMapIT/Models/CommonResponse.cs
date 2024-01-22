namespace TestMapIT.Models
{
    public class CommonResponse
    {
        public CommonResponse(bool success, string error, string message)
        {
            Success = success;
            Error = error;
            Message = message;
        }

        public CommonResponse(string error, string? message)
        {
            Success = false;
            Error = error;
            Message = message ?? string.Empty;
        }

        public CommonResponse(string message)
        {
            Success = true;
            Error = string.Empty;
            Message = message;
        }

        public bool Success { get; set; }

        public string Error { get; set; }

        public string Message { get; set; }
    }
}
