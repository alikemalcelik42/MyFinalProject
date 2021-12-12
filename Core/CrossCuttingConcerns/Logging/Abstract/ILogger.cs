using Core.Utilities.Results.Abstract;

namespace Core.CrossCuttingConcerns.Logging.Abstract
{
    public interface ILogger
    {
        public IResult Log(string data);
    }
}
