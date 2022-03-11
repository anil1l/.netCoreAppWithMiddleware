using System;
using System.Runtime.Serialization;

namespace PayrollService.Model.Exceptions
{
    [Serializable]
    public class DefaultException : Exception
    {
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public DefaultException()
        {

        }
        public DefaultException(string className, string methodName, string exceptionMessage)
            : base(exceptionMessage)
        {
            this.ClassName = className;
            this.MethodName = methodName;
        }

        public DefaultException(string className, string methodName, string exceptionMessage, Exception exception)
          : base(exceptionMessage, exception)
        {
            this.ClassName = className;
            this.MethodName = methodName;
        }


        public DefaultException(string className, string methodName, Exception inner)
          : base(inner.Message, inner)
        {
            this.ClassName = className;
            this.MethodName = methodName;
        }

        public DefaultException(string name)
            : base(String.Format("Invalid Name: {0}", name))
        {

        }

        protected DefaultException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
    }
}
