using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RRLab.Utilities
{
    public class ProgressCallbackDynamicallyInvokedTask
    {
        private object[] _MethodArguments;

        public object[] MethodArguments
        {
            get { return _MethodArguments; }
            set { _MethodArguments = value; }
        }
	
        private Delegate _Method;
        public Delegate Method
        {
            get { return _Method; }
            set { _Method = value; }
        }

        private IProgressCallback _ProgressCallback;
        public IProgressCallback ProgressCallback
        {
            get { return _ProgressCallback; }
            set { _ProgressCallback = value; }
        }

        private bool _NotifyBegin = true;

        public bool NotifyBegin
        {
            get { return _NotifyBegin; }
            set { _NotifyBegin = value; }
        }

        /// <summary>
        /// A utility class for executing a 
        /// Note: Callback is not passed to the method. If necessary, it must be provided in the method arguments.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="method"></param>
        /// <param name="args"></param>
        public ProgressCallbackDynamicallyInvokedTask(IProgressCallback callback, Delegate method, params object[] args)
        {
            Method = method;
            MethodArguments = args;
            ProgressCallback = callback;
        }

        public virtual IAsyncResult BeginExecute(AsyncCallback callback, object @object)
        {
            ThreadStart start = new ThreadStart(Execute);
            return start.BeginInvoke(callback, @object);
        }

        /// <summary>
        /// Dynamically invokes the method specified by the Method property using
        /// the arguments listed in Arguments. Execution of the method is delayed until StartTrigger is set to true.
        /// If NotifyBegin is true, IProgressCallback.Begin() is called.
        /// Otherwise, it is assumed the invoked method will call it.
        /// If an error occurs, ProgressCallback.NotifyError()
        /// is called. Finally, ProgressCallback.End() is called.
        /// This method is intended to be used as a ThreadStart.
        /// </summary>
        public virtual void Execute()
        {
            try
            {
                // Wait for start trigger
                while (!ProgressCallback.StartTrigger)
                {
                    Thread.Sleep(10);
                }
                if(NotifyBegin)
                    ProgressCallback.Begin(1, 100);

                Method.DynamicInvoke(MethodArguments);
            }
            catch (System.Threading.ThreadInterruptedException e)
            {
                ProgressCallback.NotifyError(new ExceptionEventArgs("Thread interrupted.", e));
            }
            catch (System.Threading.ThreadAbortException e)
            {
                ProgressCallback.NotifyError(new ExceptionEventArgs("Thread aborted.", e));
            }
            catch (Exception e)
            {
                ProgressCallback.NotifyError(new ExceptionEventArgs(e.InnerException));
            }
            finally
            {
                ProgressCallback.End();
            }
        }

        public virtual void EndExecute(IAsyncResult ar)
        {
            ThreadStart start = new ThreadStart(Execute);
            start.EndInvoke(ar);
        }
        public virtual void EndExecuteAfterTrigger(IAsyncResult ar)
        {
            EndExecute(ar);
        }
    }
}
