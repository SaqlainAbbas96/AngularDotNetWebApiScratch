using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ExperienceController : ApiController
    {
        public HttpResponseMessage Get()
        {
            SqlConnection sc = Connection.GetConnect();
            string query = "select * from Experience";
            SqlCommand cmd = new SqlCommand(query,sc);
            DataTable data = new DataTable();
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(data);
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/Experience/GetAllEmployeeNames")]
        public HttpResponseMessage GetAllEmployeeNames()
        {
            SqlConnection sc = Connection.GetConnect();
            string query = "select * from dbo.Employee";
            SqlCommand cmd = new SqlCommand(query, sc);
            DataTable data = new DataTable();
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(data);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        public string Post(Experience exp)
        {
            try
            {
                SqlConnection sc = Connection.GetConnect();
                string query = "insert into dbo.Experience values( '" + exp.Employee + "', '" + exp.ExperienceYear + "', '" + exp.ExperienceDescription + "')";
                SqlCommand cmd = new SqlCommand(query, sc);
                DataTable data = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(data);
                }
                return "Added Successfully";
            }
            catch (Exception e)
            {
                return "Failed to Add";
            }
        }

        public string Put(Experience exp)
        {
            try
            {
                SqlConnection sc = Connection.GetConnect();
                string query = "Update dbo.Experience set Employee = '" + exp.Employee + "', ExperienceYear = '" + exp.ExperienceYear + "', ExperienceDescription = '" + exp.ExperienceDescription + "' where ExperienceId = '" + exp.ExperienceId + "' ";
                SqlCommand cmd = new SqlCommand(query, sc);
                DataTable data = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(data);
                }
                return "Updated Successfully";
            }
            catch (Exception e)
            {
                return "Failed to Update";
            }
        }

        public string Delete(int id)
        {
            try
            {
                SqlConnection sc = Connection.GetConnect();
                string query = "Delete from dbo.Experience where ExperienceId = '" + id + "' ";
                SqlCommand cmd = new SqlCommand(query, sc);
                DataTable data = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(data);
                }
                return "Deleted Successfully";
            }
            catch (Exception e)
            {
                return "Failed to Delete";
            }
        }
    }
}
