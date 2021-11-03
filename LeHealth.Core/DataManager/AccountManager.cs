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
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LeHealth.Core.DataManager
{
    public class AccountManager : IAccountManager, IDisposable
    {
        bool disposed = false;

        private readonly string _connStr;
        private readonly string _key;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializing connection string
        /// </summary>
        /// <param name="_configuration"></param>
        public AccountManager(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("NetroxeDb");
            _key = configuration["ApplicationSettings:JWT_Secret"].ToString();
            _configuration = configuration;
        }

        //Garbage Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

            }

            disposed = true;
        }

        ~AccountManager()
        {
            Dispose(false);
        }

        public List<LoginOutputModel> Login(CredentialModel credential)
        {
            List<LoginOutputModel> userDetails = new List<LoginOutputModel>();
            using (SqlConnection con = new SqlConnection(_connStr))
            {

                string AppQuery = "[stLH_Login]";
                using (SqlCommand cmd = new SqlCommand(AppQuery, con))
                {
                    con.Open();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", credential.Username);
                    cmd.Parameters.AddWithValue("@Password", credential.Password);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    con.Close();
                    if ((ds != null) && (ds.Tables.Count > 0) && (ds.Tables[0] != null) && (ds.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            LoginOutputModel obj = new LoginOutputModel();
                            obj.UserId = ds.Tables[0].Rows[i]["UserId"].ToString();
                            obj.Username = ds.Tables[0].Rows[i]["UserName"].ToString();
                            obj.Usersname = ds.Tables[0].Rows[i]["UsersName"].ToString();
                            obj.Usertype = ds.Tables[0].Rows[i]["UserType"].ToString();
                            obj.UserState = ds.Tables[0].Rows[i]["State"].ToString();
                            obj.UserActive = ds.Tables[0].Rows[i]["Active"].ToString();
                            obj.BlockReason = ds.Tables[0].Rows[i]["BlockReason"].ToString();
                            userDetails.Add(obj);
                        }
                    }
                    return userDetails;
                }
            }
        }

        public string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var Subject = new ClaimsIdentity(new Claim[] { });

            var token = new JwtSecurityToken(_configuration["ApplicationSettings:Issuer"],
             _configuration["ApplicationSettings:Issuer"],
             null,
             expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]{}),
            //    Expires = DateTime.UtcNow.AddDays(1),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //var token = tokenHandler.WriteToken(securityToken);
            //return token;
        }
    }
}
