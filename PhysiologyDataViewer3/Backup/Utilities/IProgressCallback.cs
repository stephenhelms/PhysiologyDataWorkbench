using System;
using System.Collections.Generic;
using System.Text;

namespace RRLab.Utilities
{
    /// This defines an interface which can be implemented by UI elements
    /// which indicate the progress of a long operation.
    /// (See ProgressWindow for a typical implementation)
    /// (From the C# Corner), with some mods by me
    public interface IProgressCallback
    {
        /// Call this method from the worker thread to initialize
        /// the progress callback.
        void Begin(int minimum, int maximum);

        /// Call this method from the worker thread to initialize
        /// the progress callback, without setting the range
        void Begin();

        /// Call this method from the worker thread to reset the range in the 
        /// progress callback
        void SetRange(int minimum, int maximum);

        /// Call this method from the worker thread to update the progress text.
        void SetTaskInfo(string text);

        /// Call this method from the worker thread to increase the progress 
        /// counter by a specified value.
        void StepTo(int val);

        /// Call this method from the worker thread to step the progress meter to a
        /// particular value.
        void Increment(int val);

        /// If this property is true, then you should abort work
        bool IsAborting
        {
            get;
        }

        /// <summary>
        /// Execution should not begin until this is true
        /// </summary>
        bool StartTrigger
        {
            get;
        }

        /// Call this method from the worker thread to finalize the progress meter
        void End();

        /// <summary>
        /// Forwards an exception that occurs on the work thread
        /// </summary>
        /// <param name="e"></param>
        void NotifyError(ExceptionEventArgs e);

        /// <summary>
        /// Called when the task has successfully finished (the thread may continue execution, however,
        /// until End is called.
        /// </summary>
        void NotifyFinished();

        /// <summary>
        /// Sets the title of the group of tasks
        /// </summary>
        /// <param name="title"></param>
        void SetTitle(string title);
    }
}
