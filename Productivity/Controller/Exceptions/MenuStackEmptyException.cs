using System;

namespace Productivity.Controller.Exceptions
{
    public class MenuStackEmptyException : Exception
    {
        public MenuStackEmptyException(string exception) : base(exception){}
    }
}