using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.Utilities
{
    public class ExceptionEventArgs : EventArgs
    {
        private Exception _Exception;

        public Exception Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }

        private string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
	
	

        public ExceptionEventArgs(Exception e)
        {
            if (e == null) throw new ArgumentException("Exception must not be null.");
            Message = e.Message;
            Exception = e;
        }
        public ExceptionEventArgs(string message, Exception e)
        {
            Message = message;
            Exception = e;
        }
    }
}
