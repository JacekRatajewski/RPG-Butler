using Butler.Aplication.Abstracts.Results;

namespace Butler.Aplication.Results
{
    public class BaseResult : IBaseResult
    {
        public new bool Success { get; private set; }

        public new string Message { get; private set; }

        private BaseResult() { }

        public static IBaseResult CreateSuccess(string message = null) => new BaseResult { Success = true, Message = message ?? string.Empty };

        public static IBaseResult CreateFail(string message) => new BaseResult { Success = false, Message = message };
    }
}
