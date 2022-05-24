namespace PMA.Services.Product.API.Moldes.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = String.Empty;
        public List<string> ErrorMessage { get; set; };


    }
}
