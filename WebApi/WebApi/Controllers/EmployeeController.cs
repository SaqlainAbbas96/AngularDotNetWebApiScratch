using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        [Authorize]
        public HttpResponseMessage Get()
        {
            SqlConnection sc = Connection.GetConnect();
            //string query = "select * from dbo.Employee";
            string query =
            @"
                    select EmployeeId,EmployeeName,Department,
                    convert(varchar(10),DateOfJoining,120) as DateOfJoining,
                    PhotoFileName
                    from
                    dbo.Employee
                    ";
            SqlCommand cmd = new SqlCommand(query, sc);
            DataTable data = new DataTable();
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(data);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        public string Post(Employee emp)
        {
            try
            {
                SqlConnection sc = Connection.GetConnect();
                string query = "insert into dbo.Employee values( '" + emp.EmployeeName + "', '" + emp.Department + "', '" + emp.DateOfJoining + "', '" + emp.PhotoFileName + "')";
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

        public string Put(Employee emp)
        {
            try
            {
                SqlConnection sc = Connection.GetConnect();
                string query = "Update dbo.Employee set EmployeeName = '" + emp.EmployeeName + "', Department = '" + emp.Department + "', DateOfJoining = '" + emp.DateOfJoining + "', PhotoFileName = '" + emp.PhotoFileName + "' where EmployeeId = '" + emp.EmployeeId + "' ";
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
                string query = "Delete from dbo.Employee where EmployeeId = '" + id + "' ";
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

        [Route("api/Employee/GetAllDepartmentNames")]
        public HttpResponseMessage GetAllDepartmentNames()
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

        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos//" + filename);
                postedFile.SaveAs(physicalPath);

                return filename;

            } catch (Exception)
            {
                return "anonymous.png";
            }
        }

    }
}
