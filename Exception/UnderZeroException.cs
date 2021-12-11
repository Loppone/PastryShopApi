using System;

namespace PastryShopApi.Exceptions
{
    public class UnderZeroException : Exception
    {
        public UnderZeroException()
        {

        }

        public UnderZeroException(string message) : base(message)
        {

        }
    }
}
