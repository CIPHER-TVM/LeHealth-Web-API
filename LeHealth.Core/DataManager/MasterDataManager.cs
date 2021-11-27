using System;
using System.Collections.Generic;
using System.Text;

using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using LeHealth.Common;
using System.Globalization;

namespace LeHealth.Core.DataManager
{
    public class MasterDataManager: IMasterDataManager 
    {
        private readonly string _connStr;
        public MasterDataManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
        }

        public List<ProffessionModel> GetProfession()
        {
            List<ProffessionModel> profList = new List<ProffessionModel>();

            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetProfession", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProfId", 0);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dsProfession = new DataSet();
                    adapter.Fill(dsProfession);
                    con.Close();
                    if ((dsProfession != null) && (dsProfession.Tables.Count > 0) && (dsProfession.Tables[0] != null) && (dsProfession.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < dsProfession.Tables[0].Rows.Count; i++)
                        {
                            ProffessionModel obj = new ProffessionModel();
                            obj.ProfId = Convert.ToInt32(dsProfession.Tables[0].Rows[i]["ProfId"]);
                            obj.ProfName = dsProfession.Tables[0].Rows[i]["ProfName"].ToString();
                            profList.Add(obj);
                        }
                    }
                    return profList;
                }
            }
        }
    }
}
