using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace DPPD_Dental_Clinic_Management_System
{
    public class DataSourceConnection
    {
        public String SQLCommand;
        public DataSourceConnection()
        {       
        }

        // Get Data Table of specific SQL Query
        public DataTable GetData(string sqlCommand)
        {
            SQLCommand = sqlCommand;
            string connectionString = "Integrated Security=SSPI;" +
                "Persist Security Info=False;" +
                @"Initial Catalog=DPPD_DentalClinic_DB;Data Source=.\SQLEXPRESS";

            SqlConnection northwindConnection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(sqlCommand, northwindConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }
    }
}
