using System;

namespace AutoDealer.Miscellaneous.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message): base(message) { }
    }
}
