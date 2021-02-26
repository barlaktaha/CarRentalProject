using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base (false, message)
        {

        }
        public SuccessResult() : base(false)
        {

        }
    }
}
