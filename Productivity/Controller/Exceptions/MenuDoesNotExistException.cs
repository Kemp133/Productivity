using System;

namespace Productivity.Controller.Exceptions
{
    public class MenuDoesNotExistException : Exception
    {
        public MenuDoesNotExistException(string exception) : base(exception){}
    }
}