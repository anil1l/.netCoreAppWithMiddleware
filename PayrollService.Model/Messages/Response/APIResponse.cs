namespace PayrollService.Model.Messages.Response
{
    public class APIResponse
    {
        public string ResponseMessage { get; set; }
        public int ResponseCode { get; set; }
        public object ResponseData { get; set; }
    }
}
