using LeHealth.Common;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
namespace LeHealth.Core.DataManager
{
    public class BillManager:IBillManager
    {
        private readonly string _connStr;
        private readonly string _uploadpath;
        public BillManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
            _uploadpath = _configuration["UploadPathConfig:UplodPath"].ToString();
        }
        public List<SponsorFormModel> GetSponsorForm(SponsorFormModel frm)
        {
            List<SponsorFormModel> formList = new List<SponsorFormModel>();
            using SqlConnection con = new SqlConnection(_connStr);
            using SqlCommand cmd = new SqlCommand("stLH_GetSponsorForms", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SFormId", frm.SFormId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dtform = new DataTable();
            adapter.Fill(dtform);
            con.Close();
            if ((dtform != null) && (dtform.Rows.Count > 0))
            {
                for (Int32 i = 0; i < dtform.Rows.Count; i++)
                {
                    SponsorFormModel obj = new SponsorFormModel
                    {

                        SFormId = Convert.ToInt32(dtform.Rows[i]["SFormId"]),
                        SFormName = dtform.Rows[i]["SFormName"].ToString(),
                        BlockReason = dtform.Rows[i]["BlockReason"].ToString(),
                        IsDisplayed = Convert.ToInt32(dtform.Rows[i]["IsDisplayed"])

                    };
                    formList.Add(obj);
                }
            }
            return formList;
        }

    }
}
