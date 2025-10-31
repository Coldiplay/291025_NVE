namespace _291025_NVE.Validators
{
    public class CustomException : Exception
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
