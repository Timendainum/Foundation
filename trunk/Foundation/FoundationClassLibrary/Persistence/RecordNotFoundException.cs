using System;
using System.Runtime.Serialization;
using FoundationClassLibrary.Data;
using System.Security.Permissions;

namespace FoundationClassLibrary.Persistence
{
	[SerializableAttribute]
	public class RecordNotFoundException : Exception
	{
		#region constuctor
		public RecordNotFoundException()
		{
			_message = "RecordNotFoundException: No further information available.";
		}

		public RecordNotFoundException(string message)
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
		public RecordNotFoundException(EOperationType operationType, string source, string id)
		{
			SearchParameter = "ID: " + id;
			Operation = operationType;
			ObjectName = source;
		}

		public RecordNotFoundException(EOperationType operationType, string source, string searchField, string searchParameter)
		{
			SearchParameter = String.Format("Field: {0}: {1}", searchField, searchParameter);
			Operation = operationType;
			ObjectName = source;
		}
		public RecordNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
			
		}
		protected RecordNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			if (info == null)
                throw new ArgumentNullException("info");

			SearchParameter = info.GetString("SearchParameter");
			//Operation = EnumFormatter.ToEnum(info.GetString("Operation"), Type.GetType("EOperationType"));
			ObjectName = info.GetString("ObjectName");
			_message = info.GetString("Message");
		}
         

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("SearchParameter", SearchParameter);
			info.AddValue("Operation", Operation);
			//info.AddValue("ObjectName", ObjectName);
			info.AddValue("Message", Message);

			base.GetObjectData(info, context);
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
