using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SampleProject.Models
{
    public class StudentModel
    {
        /* ConnectionString */
        //Give Sql Server Name local,DS2 we use Data Source=Server 
        //Data Base Name=Initial Catalog
        //connecting to db through windows Authentication ie Integrated Security=true
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-L1958T5\\SQLSERVER;Initial Catalog=StudentDb;Integrated Security=true");

        //show Data
        public List<StudentDataModel> ShowStudentData()
        {
            List<StudentDataModel> listStudent = new List<StudentDataModel>();

            SqlCommand cmd = new SqlCommand("sp_getStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);//Get the data from database

            DataTable dt = new DataTable();//Create Empty data table

            da.Fill(dt);//Fillup the data table from dataAdapter object ie da

            foreach (DataRow dr in dt.Rows)//2
            {
                StudentDataModel st = new StudentDataModel();
                st.Sid = Convert.ToInt32(dr[0]);
                st.Sname = Convert.ToString(dr[1]);
                st.Fees = Convert.ToDecimal(dr[2]);

                listStudent.Add(st);

            }

            return listStudent;

        }
        //add the data

        public int SaveStudentData(StudentDataModel st)
        {
            SqlCommand cmd = new SqlCommand("sp_SaveStudentRecord", con); //jump to storeproc
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@StudentName", st.Sname);// passing value to storeproc
            cmd.Parameters.AddWithValue("@Fees", st.Fees);

            int result = cmd.ExecuteNonQuery();//Final step execute
            con.Close();
            return result;

        }
        //Get Details Based On  Id

        public StudentDataModel GetStudentDetail(int? id)
        {
            StudentDataModel st = new StudentDataModel();

            SqlCommand cmd = new SqlCommand("sp_getStudentDetailById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sid", id);// passing value to storeproc

            SqlDataAdapter da = new SqlDataAdapter(cmd);//Get the data from database

            DataTable dt = new DataTable();//Create Empty data table

            da.Fill(dt);//Fillup the data table from dataAdapter object ie da

            foreach (DataRow dr in dt.Rows)//2
            {
                st.Sid = Convert.ToInt32(dr[0]);
                st.Sname = Convert.ToString(dr[1]);
                st.Fees = Convert.ToDecimal(dr[2]);


            }

            return st;
        }

        //update the data



        public int EditStudentData(StudentDataModel st)
        {
            SqlCommand cmd = new SqlCommand("sp_updateStudentDetailById", con); //jump to storeproc
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@Sid", st.Sid);// passing value to storeproc
            cmd.Parameters.AddWithValue("@Sname", st.Sname);// passing value to storeproc
            cmd.Parameters.AddWithValue("@Fees", st.Fees);

            int result = cmd.ExecuteNonQuery();//Final step execute
            con.Close();
            return result;

        }
        //delete the data



        public int DeleteStudentData(int? id)
        {
            SqlCommand cmd = new SqlCommand("sp_deleteStudentDetailById", con); //jump to storeproc
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@Sid", id);// passing value to storeproc


            int result = cmd.ExecuteNonQuery();//Final step execute
            con.Close();
            return result;

        }

    }
}