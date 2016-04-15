using System;

namespace Tasky.Shared 
{
	/// <summary>
	/// Todo Item business object
	/// </summary>
	public class TodoItem 
	{
		public TodoItem ()
		{
		}

        public int ID { get; set; }
		public string Name { get; set; }
		//public DateTime Date { get; set; }
		public string Date {get; set;}
		public string Priority { get; set; }
		public string Reminder { get; set; }

		public string Details { get; set; }
		public bool Done { get; set; }	// TODO: add this field to the user-interface
	}
}