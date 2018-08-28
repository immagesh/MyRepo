using ApiTableReservation.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiTableReservation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TableReservationController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["TableBookingDB"].ConnectionString;

        public HttpResponseMessage POSTBkTable(Users model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("RegisterUsers", conn);
                    sqlComm.Parameters.AddWithValue("@Username", model.Username);
                    sqlComm.Parameters.AddWithValue("@Password", model.Password);
                    sqlComm.Parameters.AddWithValue("@Email", model.Email);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    affectedRows = (int)sqlComm.ExecuteScalar();
                    conn.Close();
                }
            }
            catch
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, affectedRows);
        }

        public HttpResponseMessage POSTLogIn(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("ValidateLogin", conn);
                    sqlComm.Parameters.AddWithValue("@Username", model.Username);
                    sqlComm.Parameters.AddWithValue("@Password", model.Password);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }
            }
            catch
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }

        public HttpResponseMessage GETData()
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("LoadInitialData", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }
            }
            catch
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }

        public HttpResponseMessage POSTbookTable(Users model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("TableBooking", conn);
                    sqlComm.Parameters.AddWithValue("@ResturantId", model.ResturantId);
                    sqlComm.Parameters.AddWithValue("@ApptDate", model.ApptDate);
                    sqlComm.Parameters.AddWithValue("@GuestCount", model.GuestCount);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    affectedRows = (int)sqlComm.ExecuteScalar();
                    conn.Close();
                }
            }
            catch
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, affectedRows);
        }

        public HttpResponseMessage GETAdminGrid()
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("AdminLoadData", conn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }
            }
            catch
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }

        public HttpResponseMessage POSTChangestatus(Users model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("ChangeStatus", conn);
                    sqlComm.Parameters.AddWithValue("@StatusId", model.StatusId);
                    sqlComm.Parameters.AddWithValue("@ResgistrationId", model.ResgistrationId);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    affectedRows = (int)sqlComm.ExecuteScalar();
                    conn.Close();
                }
            }
            catch
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, affectedRows);
        }
    }
}
