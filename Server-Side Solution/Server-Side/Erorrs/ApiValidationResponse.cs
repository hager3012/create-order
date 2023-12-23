namespace Server_Side.Erorrs
{
    public class ApiValidationResponse:ApiResponse
    {
        public IEnumerable<string> Erorrs { get; set; }
        public ApiValidationResponse(int statusCode)
            :base(statusCode)
        {
            Erorrs = new List<string>();
        }
    }
}
