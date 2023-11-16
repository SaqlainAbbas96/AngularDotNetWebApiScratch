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
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            SqlConnection sc = Connection.GetConnect();
            string query = "select * from dbo.Department";
            SqlCommand cmd = new SqlCommand(query, sc);
            DataTable data = new DataTable();
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(data);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        public string Post(Department dep)
        {
            try
            {
                SqlConnection sc = Connection.GetConnect();
                string query = "insert into dbo.Department values( '" + dep.DepartmentName + "')";
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

        public string Put(Department dep)
        {
            try
            {
                SqlConnection sc = Connection.GetConnect();
                string query = "update dbo.Department set DepartmentName = '" + dep.DepartmentName + "' where DepartmentId = '" + dep.DepartmentId + "' ";
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
                string query = "delete from dbo.Department where DepartmentId = '" + id + "' ";
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
