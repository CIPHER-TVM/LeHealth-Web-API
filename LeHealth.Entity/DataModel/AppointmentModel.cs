using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
	public class AppointmentModel
	{
		public Int32? ConsultantId { get; set; }
		public String AppDate { get; set; }
		public Int32 AppId { get; set; }
		public Int32 DeptId { get; set; }
		public String Name { get; set; }
		public String Mobile { get; set; }
		public String AppFromDate { get; set; }
		public String AppToDate { get; set; }
		public String Phone { get; set; }
		public String Address { get; set; }
		public String Response { get; set; }
		public String PIN { get; set; }
		public String RegNo { get; set; }
		public String Reason { get; set; } 
		public String NewStatus { get; set; }  
		public int UserId { get; set; } 
		public int AppType { get; set; }
		public int BranchId { get; set; }
	}
}
