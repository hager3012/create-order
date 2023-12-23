namespace Server_Side.Erorrs
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiResponse(int statusCode,string? message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefualtMessage(statusCode);

        }
        private string? GetDefualtMessage(int statusCode)
        {
            return statusCode switch
            {
                200=> "Success",
                404 =>"Not Found",
                400 => "A bad Request",
                500 => "Errors are the path in the dark side "
            };
        }
    }
}
