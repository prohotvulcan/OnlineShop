namespace olShop.Utilities.Dtos
{
    public class GenericResult
    {
        public object Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public object Error { get; set; }

        public GenericResult()
        {

        }

        public GenericResult(bool success)
        {
            this.Success = success;
        }

        public GenericResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        public GenericResult(bool success, object data)
        {
            this.Success = success;
            this.Data = data;
        }
    }
}
