using LeHealth.Common;
using LeHealth.Core.Interface;
using LeHealth.Entity.DataModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LeHealth.Core.DataManager
{
    public class MenuSubmenuManager : IMenuSubmenuManager
    {
        private readonly string _connStr;
        public MenuSubmenuManager(IConfiguration _configuration)
        {
            _connStr = _configuration.GetConnectionString("NetroxeDb");
           
        }
        public MenuModel GetMenuItem(int menuId)
        {
            MenuModel obj = new MenuModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetMenuItem", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@menuId", menuId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToObject<MenuModel>();
                        obj.submenuIds = new List<int>();
                    }
                    if ((ds != null) && (ds.Tables.Count > 1) && (ds.Tables[1] != null) && (ds.Tables[1].Rows.Count > 0))
                    {
                        obj.submenuIds = new List<int>();
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            obj.submenuIds.Add(Convert.ToInt32(dr.ItemArray[0].ToString()));
                        }
                    }
                    return obj;
                }
            }
        }

        public List<MenuModel> GetMenuItems()
        {
            List<MenuModel> obj = new List<MenuModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetMenuItems", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@menuId", menuId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToListOfObject<MenuModel>();
                    }
                    return obj;
                }
            }
        }

        public List<SubmenuModel> GetSubMenuItems()
        {
            List<SubmenuModel> obj = new List<SubmenuModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSubMenuItems", con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@menuId", menuId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToListOfObject<SubmenuModel>();
                    }
                    return obj;
                }
            }

        }

        public SubmenuModel GetSubmenuMenuItem(int subMenuId)
        {
            SubmenuModel obj = new SubmenuModel();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetSubmenuMenuItem", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subMenuId", subMenuId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        obj = ds.Tables[0].ToObject<SubmenuModel>();
                    }
                  
                        return obj;
                }
            }

        }

        public string SaveMenuItems(MenuModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SaveMenu", con))
                {
                    try
                    {
                       
                        var jsonSubmenu = JsonConvert.SerializeObject(obj.submenuIds);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_Mid", obj.Mid);
                        cmd.Parameters.AddWithValue("@P_Menu", obj.Menu);
                        cmd.Parameters.AddWithValue("@P_MenuAlias", obj.MenuAlias);
                        cmd.Parameters.AddWithValue("@P_Link", obj.Link);
                        cmd.Parameters.AddWithValue("@P_MenuIcon", obj.MenuIcon);
                        cmd.Parameters.AddWithValue("@P_SubMenuFlag", obj.SubMenuFlag);
                        cmd.Parameters.AddWithValue("@P_SubMenuIds",jsonSubmenu);
                        SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retValV);

                        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retDesc);
                        con.Open();
                        var isUpdated = cmd.ExecuteNonQuery();
                        con.Close();
                        var ret = retValV.Value;
                        var descrip = retDesc.Value.ToString();

                        response = descrip;
                    }
                    catch (Exception ex)
                    {
                        response = ex.Message;
                    }
                }
            }
            return response;
        }
        public List<Leftmenumodel> GetLeftmenu(int user, int branchesId)
        {
            List<Leftmenumodel> obj = new List<Leftmenumodel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetLeftMenu", con))
                {
                    try
                    {
                      
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_UserId",user);
                        cmd.Parameters.AddWithValue("@P_BranchId", branchesId);
                        

                        SqlParameter retjson = new SqlParameter("@RetJSON", SqlDbType.NVarChar, -1)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retjson);
                        con.Open();
                        var isUpdated = cmd.ExecuteNonQuery();
                        con.Close();
                        string ret = retjson.Value.ToString();
                        obj = JsonConvert.DeserializeObject<List<Leftmenumodel>>(ret);
                       
                    }
                    catch (Exception ex)
                    {
                       //obj = ex.Message;
                    }
                    return obj;
                }
            }
        }
       public List<int> GetMenuMap(int groupId)
        {
            List<int> response = new List<int>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_GetMenuMap", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_groupId", groupId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                       for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                            response.Add(Convert.ToInt32(ds.Tables[0].Rows[i]["MenuId"].ToString()));
                        }
                        
                    }

                    return response;
                }
            }

            return response;
        }
       public string SaveMenumap(MenuMap obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SaveMenumap", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var jsonmenuIds = JsonConvert.SerializeObject(obj.menuIds);
                        cmd.Parameters.AddWithValue("@P_groupId", obj.groupId);
                        cmd.Parameters.AddWithValue("@P_Json", jsonmenuIds);
                        SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retValV);

                        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retDesc);
                        con.Open();
                        var isUpdated = cmd.ExecuteNonQuery();
                        con.Close();
                        var ret = retValV.Value;
                        var descrip = retDesc.Value.ToString();

                        response = descrip;
                    }
                    catch (Exception ex)
                    {
                        response = ex.Message;
                    }
                }
            }
            return response;
        }
        public string SaveSubMenuItems(SubmenuModel obj)
        {
            string response = string.Empty;
            using (SqlConnection con = new SqlConnection(_connStr))
            {
                using (SqlCommand cmd = new SqlCommand("stLH_SaveSubMenuItems", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_Sid", obj.SId);
                        cmd.Parameters.AddWithValue("@P_SubMenu", obj.SubMenu);
                        cmd.Parameters.AddWithValue("@P_SubMenuAlias", obj.SubMenuAlias);
                        cmd.Parameters.AddWithValue("@P_SubMenuLink", obj.SubMenuLink);
                        cmd.Parameters.AddWithValue("@P_SubMenuIcon", obj.SubMenuIcon);
                        SqlParameter retValV = new SqlParameter("@RetVal", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retValV);

                        SqlParameter retDesc = new SqlParameter("@RetDesc", SqlDbType.VarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(retDesc);
                        con.Open();
                        var isUpdated = cmd.ExecuteNonQuery();
                        con.Close();
                        var ret = retValV.Value;
                        var descrip = retDesc.Value.ToString();

                        response = descrip;
                    }
                    catch (Exception ex)
                    {
                        response = ex.Message;
                    }
                }
            }
            return response;
        }
    }
}
