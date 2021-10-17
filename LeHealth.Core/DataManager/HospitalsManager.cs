using Microsoft.Extensions.Configuration;
using LeHealth.Core.Interface;
using LeHealth.Entity;
using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LeHealth.Common;

namespace LeHealth.Core.DataManager
{
  public class HospitalsManager : IHospitalsManager
  {
    private readonly string _connStr;
    public HospitalsManager(IConfiguration _configuration)
    {
      _connStr = _configuration.GetConnectionString("NetroxeDb");
    }

    public List<HospitalModel> GetUserHospitals()
    {
      List<HospitalModel> hospitalList = new List<HospitalModel>();
      using (SqlConnection con = new SqlConnection(_connStr))
      {

        using (SqlCommand cmd = new SqlCommand("stLH_GetUserHospitals", con))
        {
          con.Open();
          cmd.CommandType = CommandType.StoredProcedure;
          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          DataSet dsHospitalList = new DataSet();
          adapter.Fill(dsHospitalList);
          con.Close();


          if ((dsHospitalList != null) && (dsHospitalList.Tables.Count > 0) && (dsHospitalList.Tables[0] != null) && (dsHospitalList.Tables[0].Rows.Count > 0))
            hospitalList = dsHospitalList.Tables[0].ToListOfObject<HospitalModel>();
          return hospitalList;

        }
      }

    }
    public List<DepartmentModel> GetDepartments()
    {
      List<DepartmentModel> departmentlist = new List<DepartmentModel>();
      using (SqlConnection con = new SqlConnection(_connStr))
      {

        using (SqlCommand cmd = new SqlCommand("stLH_GetDepartment", con))
        {
          con.Open();
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@DeptId", 0);
          cmd.Parameters.AddWithValue("@Active", 1);
          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          DataSet ds = new DataSet();
          adapter.Fill(ds);
          con.Close();
          if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
          {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
              DepartmentModel obj = new DepartmentModel();
              obj.DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]);
              obj.DeptName = ds.Tables[0].Rows[i]["DeptName"].ToString();
              obj.DeptCode = ds.Tables[0].Rows[i]["DeptCode"].ToString();
              obj.Active = Convert.ToInt32(ds.Tables[0].Rows[i]["Active"]);
              obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
              departmentlist.Add(obj);
            }
          }
          return departmentlist;
        }
      }
    }
    public List<ConsultantModel> GetConsultant(int deptId)
    {
      List<ConsultantModel> consultantList = new List<ConsultantModel>();
      using (SqlConnection con = new SqlConnection(_connStr))
      {

        using (SqlCommand cmd = new SqlCommand("stLH_GetConsultantOfDept", con))
        {
          con.Open();
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@DeptId", deptId); // avoid hard coding
          cmd.Parameters.AddWithValue("@ShowExternal", false);
          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          DataSet ds = new DataSet();
          adapter.Fill(ds);
          con.Close();
          if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
          {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
              ConsultantModel obj = new ConsultantModel();
              obj.ConsultantId = Convert.ToInt32(ds.Tables[0].Rows[i]["ConsultantId"]);
              obj.ConsultantName = ds.Tables[0].Rows[i]["ConsultantName"].ToString();
              //obj.ConsultantCode = ds.Tables[0].Rows[i]["ConsultantCode"].ToString();
              obj.DeptId = Convert.ToInt32(ds.Tables[0].Rows[i]["DeptId"]);
              consultantList.Add(obj);
            }
          }
          return consultantList;
        }
      }
    }

    public List<Appointments> GetAppointments(AppointmentModel appointment)
    {
      List<Appointments> Appointmentlist = new List<Appointments>();
      using (SqlConnection con = new SqlConnection(_connStr))
      {

        string AppQuery = "[stLH_GetAppOfaDay]";
        using (SqlCommand cmd = new SqlCommand(AppQuery, con))
        {
          con.Open();

          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@ConsultantId", appointment.ConsultantId);
          cmd.Parameters.AddWithValue("@AppDate", appointment.AppDate);
          cmd.Parameters.AddWithValue("@DeptId", 0);

          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          DataSet ds = new DataSet();
          adapter.Fill(ds);
          con.Close();
          if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
          {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
              Appointments obj = new Appointments();
              obj.AppId = Convert.ToInt32(ds.Tables[0].Rows[i]["AppId"]);
              obj.AppType = ds.Tables[0].Rows[i]["AppType"].ToString();
              obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
              obj.TimeNo = ds.Tables[0].Rows[i]["TimeNo"].ToString();
              obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();
              obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
              Appointmentlist.Add(obj);
            }
          }
          return Appointmentlist;
        }
      }
    }
    public List<ConsultationModel> GetConsultation(ConsultantModel consultation)
    {
      List<ConsultationModel> Appointmentlist = new List<ConsultationModel>();
      using (SqlConnection con = new SqlConnection(_connStr))
      {
        using (SqlCommand cmd = new SqlCommand("stLH_GetConsultation", con))
        {
          con.Open();
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@Status", "W");
          cmd.Parameters.AddWithValue("@ConsultantId", consultation.ConsultantId);
          cmd.Parameters.AddWithValue("@ConsultDate", consultation.ConsultantDate);
          cmd.Parameters.AddWithValue("@BranchId", 0);

          
          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          DataSet ds = new DataSet();
          adapter.Fill(ds);
          con.Close();
          if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
          {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
              ConsultationModel obj = new ConsultationModel();
              obj.TokenNO = ds.Tables[0].Rows[i]["TokenNO"].ToString();
              obj.Sponsor = ds.Tables[0].Rows[i]["Sponsor"].ToString();
              obj.PatientName = ds.Tables[0].Rows[i]["PatientName"].ToString();
              obj.TimeNo = (ds.Tables[0].Rows[i]["TimeNo"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["TimeNo"]);
              obj.RegNo = ds.Tables[0].Rows[i]["RegNo"].ToString();// == DBNull.Value) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[i]["RegNo"]);//int.Parse(ds.Tables[0].Rows[i]["RegNo"].ToString());
              obj.Status = ds.Tables[0].Rows[i]["Status"].ToString();
              Appointmentlist.Add(obj);
            }
          }
          return Appointmentlist;
        }
      }
    }

    public List<Appointments> InsertUpdateAppointment(Appointments appointments)
    {
      List<Appointments> appointmentsList = new List<Appointments>();
      using (SqlConnection con = new SqlConnection(_connStr))
      {

        using (SqlCommand cmd = new SqlCommand("stLH_InsertAppointment", con))
        {
          cmd.CommandType = CommandType.StoredProcedure;
          if (appointments == null || appointments.PatientId <= 0)
            cmd.Parameters.AddWithValue("@PatientId", DBNull.Value);

          else
            cmd.Parameters.AddWithValue("@PatientId", appointments.PatientId);

          cmd.Parameters.AddWithValue("@AppId", appointments.AppId);
          cmd.Parameters.AddWithValue("@ConsultantId", appointments.ConsultantId);
          cmd.Parameters.AddWithValue("@EntryDate", DateTime.Now);
          cmd.Parameters.AddWithValue("@AppDate", DateTime.Now);
          cmd.Parameters.AddWithValue("@AppNo", appointments.AppNo);
          cmd.Parameters.AddWithValue("@SliceNo", appointments.SliceNo);
          cmd.Parameters.AddWithValue("@SliceTime", appointments.SliceTime);
          cmd.Parameters.AddWithValue("@Title", appointments.Title);
          cmd.Parameters.AddWithValue("@FirstName", appointments.FirstName);
          cmd.Parameters.AddWithValue("@MiddleName", appointments.MiddleName);
          cmd.Parameters.AddWithValue("@LastName", appointments.LastName);
          cmd.Parameters.AddWithValue("@Address1", appointments.Address1);
          cmd.Parameters.AddWithValue("@Address2", appointments.Address2);
          cmd.Parameters.AddWithValue("@Street", appointments.Street);
          cmd.Parameters.AddWithValue("@PlacePo", appointments.PlacePO);
          cmd.Parameters.AddWithValue("@PIN", appointments.PIN);
          cmd.Parameters.AddWithValue("@City", appointments.City);
          cmd.Parameters.AddWithValue("@State", appointments.State);
          cmd.Parameters.AddWithValue("@CountryId", appointments.CountryId);
          cmd.Parameters.AddWithValue("@Mobile", appointments.Mobile);
          cmd.Parameters.AddWithValue("@ResPhone", appointments.ResPhone);
          cmd.Parameters.AddWithValue("@OffPhone", appointments.OffPhone);
          cmd.Parameters.AddWithValue("@Email", appointments.Email);
          cmd.Parameters.AddWithValue("@Remarks", appointments.Remarks);
          cmd.Parameters.AddWithValue("@Reminder", appointments.Reminder);
          cmd.Parameters.AddWithValue("@AppStatus", appointments.AppStatus);
          cmd.Parameters.AddWithValue("@CancelReason", appointments.CancelReason);
          cmd.Parameters.AddWithValue("@UserId", appointments.UserId);
          cmd.Parameters.AddWithValue("@AppTypeId", appointments.appTypeId);
          cmd.Parameters.AddWithValue("@SessionId", appointments.SessionId);
          cmd.Parameters.AddWithValue("@RetVal", appointments.RetVal);
          cmd.Parameters.AddWithValue("@RetDesc", appointments.RetDesc);
          con.Open();
          var isUpdated = cmd.ExecuteNonQuery();
          con.Close();

        }
      }
      return appointmentsList;
    }
    public List<ConsultationModel> InsertUpdateConsultation(ConsultationModel consultations)
    {
      List<ConsultationModel> consultaionsList = new List<ConsultationModel>();
      using (SqlConnection con = new SqlConnection(_connStr))
      {

        using (SqlCommand cmd = new SqlCommand("stLH_InsertUpdateConsultation", con))
        {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.AddWithValue("@ConsultationId", consultations.ConsultationId);
          cmd.Parameters.AddWithValue("@ConsultDate", DateTime.Now);
          cmd.Parameters.AddWithValue("@AppId", consultations.AppId);
          cmd.Parameters.AddWithValue("@ConsultantId", consultations.ConsultantId);
          cmd.Parameters.AddWithValue("@PatientId", consultations.PatientId);
          cmd.Parameters.AddWithValue("@Symptoms", consultations.Symptoms);
          cmd.Parameters.AddWithValue("@ConsultFee", consultations.ConsultFee);
          cmd.Parameters.AddWithValue("@ConsultType", consultations.ConsultType);
          cmd.Parameters.AddWithValue("@EmerFee", consultations.EmerFee);
          cmd.Parameters.AddWithValue("@Emergency", consultations.Emergency);
          cmd.Parameters.AddWithValue("@ItemId", consultations.ItemId);
          cmd.Parameters.AddWithValue("@AgentId", consultations.AgentId);
          cmd.Parameters.AddWithValue("@LocationId", consultations.LocationId);
          cmd.Parameters.AddWithValue("@LeadAgentId", consultations.LeadAgentId);
          cmd.Parameters.AddWithValue("@InitiateCall", consultations.InitiateCall);
          cmd.Parameters.AddWithValue("@UserId", consultations.UserId);
          cmd.Parameters.AddWithValue("@RetSeqNo", consultations.RetSeqNo);
          cmd.Parameters.AddWithValue("@SessionId", consultations.SessionId);
          cmd.Parameters.AddWithValue("@RetVal", consultations.RetVal);
          cmd.Parameters.AddWithValue("@RetDesc", consultations.RetDesc);
          con.Open();
          var isUpdated = cmd.ExecuteNonQuery();
          con.Close();
        }
      }
      return consultaionsList;
    }

  }
}
