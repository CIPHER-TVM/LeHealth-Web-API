using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
	public class AppointmentModel
	{
		public Int32? ConsultantId { get; set; }
		public string AppDate { get; set; }
		public Int32 AppId { get; set; }
		public Int32 DeptId { get; set; }
		public string Name { get; set; }
		public string Mobile { get; set; }
		public string AppFromDate { get; set; }
		public string AppToDate { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string PIN { get; set; }
		public string RegNo { get; set; }


	}
}
