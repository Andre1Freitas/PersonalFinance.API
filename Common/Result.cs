namespace PersonalFinance.API.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Error { get; }

        private Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, "");
        public static Result Failure(string error) => new Result(false, error);
    }
}
