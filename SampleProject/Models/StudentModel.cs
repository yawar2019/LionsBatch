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
        //update the data
        //delete the data

    }
}