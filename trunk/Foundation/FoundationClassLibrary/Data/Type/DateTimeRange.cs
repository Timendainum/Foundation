using System;

namespace FoundationClassLibrary.Data.Type
{
	public class DateTimeRange : DataTypeBase, ICloneable
	{
		#region constructors
		public DateTimeRange()
		{
			Start = DateTime.MinValue;
			End = DateTime.MinValue;
		}

		/// <summary>
		/// Creates a new DataTimeRange object
		/// </summary>
		/// <param name="start">Start DateTime</param>
		/// <param name="end">End DateTime</param>
		public DateTimeRange(DateTime start, DateTime end)
		{
			Start = start;
			End = end;
		}
		#endregion

		#region properties
		public DateTime Start { get; set; }
		public DateTime End { get; set; }
		#endregion

		#region ICloneable Members
		public object Clone()
		{
			return new DateTimeRange(this.Start, this.End);
		}
		#endregion
	}
}
