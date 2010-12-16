using System;
using System.Runtime.Serialization;
using FoundationClassLibrary.Data;

namespace FoundationClassLibrary.Persistence
{
	public class ExceptionRecordNotFound : Exception
	{
		#region constuctor
		public ExceptionRecordNotFound()
		{
			_message = "ExceptionRecordNotFound: No further information available.";
		}

		public ExceptionRecordNotFound(string message)
			: base(message)
		{
			_message = message;
		}
		
		
		/// <summary>
		/// Creates an instance of ExceptionRecordNotFound.
		/// </summary>
		/// <param name="operationType">What type of operation was in progress when this exception was raised.</param>
		/// <param name="source">The object or table that was being accessed when the exception occurred.</param>
		/// <param name="id">The Id of the record that was being worked with.</param>
		public ExceptionRecordNotFound(EOperationType operationType, string source, string id)
		{
			SearchParameter = "ID: " + id;
			Operation = operationType;
			ObjectName = source;
		}

		public ExceptionRecordNotFound(EOperationType operationType, string source, string searchField, string searchParameter)
		{
			SearchParameter = String.Format("Field: {0}: {1}", searchField, searchParameter);
			Operation = operationType;
			ObjectName = source;
		}
		public ExceptionRecordNotFound(string message, Exception innerException)
			: base(message, innerException)
		{
			
		}
		protected ExceptionRecordNotFound(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			_message = "ExceptionRecordNotFound: No further information available.";
		}
         
		#endregion
		#region fields
		private string _message = string.Empty;
		#endregion

		#region Properties
		public string SearchParameter { get; set; }
		public EOperationType Operation { get; set; }
		public string ObjectName { get; set; }
		public override string Message
		{
			get
			{
				if (string.IsNullOrEmpty(_message))
					return String.Format("ExceptionRecordNotFound: Object {0} {1} record could not be found during a {2} operation.", ObjectName, SearchParameter, EnumFormatter.ToString(Operation));
				else
					return _message;
			}
		}
		#endregion
	}
}
