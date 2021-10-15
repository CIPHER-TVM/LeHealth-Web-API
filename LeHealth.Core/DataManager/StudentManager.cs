using Microsoft.Extensions.Configuration;
using LeHealth.Core.Interface;
using LeHealth.Entity;
using LeHealth.Entity.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LeHealth.Core.DataManager
{
    public class StudentManager : IStudentManager
    {

        private readonly string connectionString;
        public StudentManager(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("NetroxeDb");
        }
        public async Task<StudentDataModel> CreateStudent(StudentDataModel student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertNewStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("P_ID", student.Id);
                    cmd.Parameters.AddWithValue("P_NAME", student.Name);
                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return student;

                }

            }
        }

        public async Task<int> DeleteStudent(int studentId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("P_ID", studentId);
                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    return studentId;
                }
            }
        }

        public async Task<StudentDataModel> GetStudentDetailsById(int studentId)
        {
            StudentDataModel studentData = new StudentDataModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("P_ID", studentId);
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        var reader = await cmd.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {
                                studentData.Id = (int)reader["student_id"];
                                studentData.Name = (string)reader["student_name"];
                            }
                        }
                    }
                    con.Close();
                }
            }
            return studentData;
        }

        public async Task<List<StudentDataModel>> GetStudents()
        {
            List<StudentDataModel> studentList = new List<StudentDataModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllStudents", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        await Task.Run(() => sda.Fill(dt));
                       

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            studentList.Add(new StudentDataModel()
                            {
                                Id = Convert.ToInt32(dt.Rows[i][0].ToString()),
                                Name = dt.Rows[i][1].ToString()
                            });
                        }

                    }
                }
            }
            return studentList;
        }

        public async Task<StudentDataModel> UpdateStudent(StudentDataModel student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateAllStudents", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("P_ID", student.Id);
                    cmd.Parameters.AddWithValue("P_NAME", student.Name);
                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();
                    return student;
                }

            }
        }
    }
}
