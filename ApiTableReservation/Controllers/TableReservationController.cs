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
                    sqlComm.Parameters.AddWithValue("@Phonenumber", model.Phonenumber);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    affectedRows = (int)sqlComm.ExecuteScalar();
                    conn.Close();
                }
            }
            catch (Exception ex)
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
                    sqlComm.Parameters.AddWithValue("@notes", model.notes);
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

        public HttpResponseMessage POSTResDetails(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("GetRestuarantDetails", conn);
                    sqlComm.Parameters.AddWithValue("@ResturantId", model.ResturantId);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
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

        public HttpResponseMessage POSTUserGrid(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("AdminLoadData", conn);
                    sqlComm.Parameters.AddWithValue("@userId", model.UserId);
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

        public HttpResponseMessage POSTBookmark(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("BookMarkResturant", conn);
                    sqlComm.Parameters.AddWithValue("@userId", model.UserId);
                    sqlComm.Parameters.AddWithValue("@ResturantId", model.ResturantId);
                    sqlComm.Parameters.AddWithValue("@bookmarkId", model.BookmarkId);
                    sqlComm.Parameters.AddWithValue("@Isactive", model.Isactive);

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

        public HttpResponseMessage POSTUserBookmarks(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("GETUserBookmark", conn);
                    sqlComm.Parameters.AddWithValue("@userId", model.UserId);
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

        public HttpResponseMessage POSTdelteBkmrk(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("DeleteUserBookmark", conn);
                    sqlComm.Parameters.AddWithValue("@BookmarkId", model.BookmarkId);
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

        public HttpResponseMessage POSTAdminRole(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("GetAdminRole", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.Parameters.AddWithValue("@Callfrm", model.Callfrm);
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

        public HttpResponseMessage POSTmakeadmin(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("AdminAccess", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.Parameters.AddWithValue("@Isadmin", model.Isadmin);
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

        public HttpResponseMessage POSTRecentbookings(Users model)
        {
            DataSet ds = new DataSet("TimeRanges");
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("GetRecentBookings", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
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

        public HttpResponseMessage POSTAddRestu(Users model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("AddResturant", conn);
                    sqlComm.Parameters.AddWithValue("@Resturantname", model.Resturantname);
                    sqlComm.Parameters.AddWithValue("@Resturantaddr", model.Resturantaddr);
                    sqlComm.Parameters.AddWithValue("@Resturantavgcost", model.Resturantavgcost);
                    sqlComm.Parameters.AddWithValue("@resid", model.resid);
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
