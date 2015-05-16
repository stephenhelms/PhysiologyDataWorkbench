using System;

namespace RRLab.PhysiologyWorkbench.Data
{
	/// <summary>
	/// <c>Annotation</c> objects store commentary information about a physiology data object.
	/// </summary>
	[Serializable()]
	public class Annotation
	{
		/**
		 *	<summary>
		 *	<c>Annotation(String text)</c> creates an <c>Annotation</c> object with the <c>Text</c>
		 *	property set to <c>text</c>. The <c>Time</c> property is set to <c>DateTime.Now</c>.
		 *	</summary>
		 **/
		public Annotation(String text, string user) 
		{
			this.Text = text;
			this.Time = DateTime.Now;
            this.User = user;
		}
		/**
		 *	<summary>
		 *	<c>Annotation(DateTime time, String text)</c> creates an <c>Annotation</c> object with the <c>Text</c>
		 *	property set to <c>text</c> and the <c>Time</c> property set to <c>time</c>. <c>time</c> should be in Utc format.
		 *	</summary>
		 **/
		public Annotation(DateTime time, String text, string user)
		{
			this.Text = text;
			this.Time = time;
            this.User = user;
		}

		/**
		 *	<summary>
		 *	<c>ToString()</c> returns the Annotation as {Time}: {Text}.
		 *	</summary>
		 **/
		public override string ToString()
		{
			return this.Time.ToLocalTime().ToString("t") + ": " + this.Text;
		}


		private String _Text;
		/**
		 *	<summary>
		 *	<c>Text</c> contains the Annotation's message.</c>
		 *	</summary>
		 **/
		public String Text 
		{
			get 
			{
				return _Text;
			}
			set 
			{
				_Text = value;
			}
		}
		private DateTime _Time = DateTime.Now;
		/**
		 *	<summary>
		 *	<c>Time</c> contains the <c>DateTime</c> corresponding with the time the annotation was created.
		 *	The default value is <c>DateTime.Now</c>.
		 **/
		public DateTime Time 
		{
			get 
			{
				return _Time;
			}
			set 
			{
				_Time = value;
			}
		}

        private string _User;

        public string User
        {
            get { return _User; }
            set { _User = value; }
        }
	
	}
}
