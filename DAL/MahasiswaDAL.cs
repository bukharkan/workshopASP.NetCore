using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WorkshopACCICore.Models;

namespace WorkshopACCICore.DAL
{
    public class MahasiswaDAL : IMahasiswa
    {
        private IConfiguration _config;

        public MahasiswaDAL(IConfiguration config)
        {
            _config = config;
        }
        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
        
        public void Delete(Mahasiswa mahasiswa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mahasiswa> GetAll()
        {
            List<Mahasiswa> lstMhs = new List<Mahasiswa>();
            using(SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Mahasiswa order by Name asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        lstMhs.Add(new Mahasiswa
                        {
                            Nim = Convert.ToString(data["Nim"]).ToString(),
                            Name = data["Name"].ToString()

                        });
                    }
                }
                data.Close();
                cmd.Dispose();
                conn.Close();
                return lstMhs;
            }
        }

        public Mahasiswa GetById(string id)
        {
            Mahasiswa mhs = new Mahasiswa();
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string query = @"select * from Mahasiswa Where Nim=@Nim";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nim", id);
                conn.Open();
                SqlDataReader data = cmd.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        mhs.Nim = Convert.ToString(data["Nim"]).ToString();
                        mhs.Name = data["Name"].ToString();
                    }
                }
                data.Close();
                cmd.Dispose();
                conn.Close();
            }
            return mhs;
        }

        public void Insert(Mahasiswa mahasiswa)
        {
            throw new NotImplementedException();
        }

        public void Update(Mahasiswa mahasiswa)
        {
            throw new NotImplementedException();
        }
    }
}
