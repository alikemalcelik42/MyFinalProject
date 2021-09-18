using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(true, message)
        {

        }

        public ErrorResult() : base(true)
        {

        }
    }
}
