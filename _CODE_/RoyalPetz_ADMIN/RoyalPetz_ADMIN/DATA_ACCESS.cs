﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace RoyalPetz_ADMIN
{
    class Data_Access
    {
        private MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
        
        private MySqlTransaction myTrans;
        private MySqlCommand myTransCommand;
        public bool connectToLive = true;
        private static string configFileConnectionString = "";
        private static string ipServer = "";
        //private string myConnectionString = "server=127.0.0.1;uid=SYS_POS_ADMIN;pwd=pass123;database=SYS_POS;";
        private string configFile = "pos.cfg";
        private MySqlConnection transConnection;

        public bool setIPServer()
        {
            string s = "";

            if (configFileConnectionString.Length <= 0)
            {
                if (File.Exists(configFile))
                {
                    using (StreamReader sr = File.OpenText(configFile))
                    {
                        if ((s = sr.ReadLine()) != null)
                        {
                            configFileConnectionString = "server=" + s + ";uid=SYS_POS_ADMIN;pwd=pass123;database=SYS_POS;";
                            ipServer = s;
                        }
                    }
                    return true;
                }
            }
            else
                return true;
            
            return false;
        }

        public string getIPServer()
        {
            return ipServer;
        }

        public void setConfigFileConnectionString(string ipAddress)
        {            
            configFileConnectionString = "server=" + ipAddress + ";uid=SYS_POS_ADMIN;pwd=pass123;database=SYS_POS;";
            ipServer = ipAddress;
        }

        public bool testConfigConnectionString(ref MySqlException returnEx)
        {
            try
            {
                conn.ConnectionString = configFileConnectionString;
                conn.Open();
                conn.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                returnEx = ex;
                return false;
            }
        }

        public MySqlConnection getDSConn()
        {
            return conn;
        }

        public bool firstMySqlConnect()
        {
            try
            {
                if (setIPServer())
                {
                    conn.ConnectionString = configFileConnectionString;//myConnectionString;
                    conn.Open();

                    return true;
                }
                else
                    return false;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        public bool mySqlConnect()
        {     
            try
            {
                    conn.ConnectionString = configFileConnectionString;//myConnectionString;
                    conn.Open();

                    return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }

        public void mySqlClose()
        {
            if (null != conn)
            { 
                conn.Close();
            }
        }

        public Boolean writeXML(string sqlCommand, string filename = "")
        {
            Boolean rslt = false;
            DataSet myData = new DataSet();
            MySqlCommand cmd;
            MySqlDataAdapter myAdapter;
            
            cmd = new MySqlCommand();
            myAdapter = new MySqlDataAdapter();
            if (conn.State.ToString() != "Open")
                mySqlConnect();
            //cmd = new MySqlCommand(sqlCommand, conn);

            try
            {
                cmd.CommandText = sqlCommand;
                cmd.Connection = conn;

                myAdapter.SelectCommand = cmd;
                myAdapter.Fill(myData);
                if (filename.Equals(""))
                {
                    filename = "\\dataset.xml";
                } else
                {
                    filename = "\\" + filename;
                }
                string appPath = Directory.GetCurrentDirectory() + filename;
                myData.WriteXml(@appPath, XmlWriteMode.WriteSchema);
                rslt = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                rslt = false;
            }
            return rslt;
        }

        public MySqlDataReader getData(string sqlCommand)
        {
            MySqlCommand cmd;
            MySqlDataReader rdr; 

            if (conn.State.ToString() != "Open")
                mySqlConnect();

            cmd  = new MySqlCommand(sqlCommand, conn);
            rdr = cmd.ExecuteReader();

            return rdr;
        }

        public object getDataSingleValue(string sqlCommand)
        {
            if (conn.State.ToString() != "Open")
                mySqlConnect();

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);
            object result = cmd.ExecuteScalar();

            return result;
        }

        public bool executeNonQueryCommand(string sqlCommand)
        {
            bool retVal = true;
            //myConnectionString = Properties.Settings.Default.connectionString;
            int temp;
           
            try
            {
                myTransCommand.CommandText = sqlCommand;
                if (myTransCommand.Connection.State.ToString() != "Open")
                    myTransCommand.Connection.Open();

                temp = myTransCommand.ExecuteNonQuery();

                retVal = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                retVal = false;
            }

            return retVal;
        }

        public bool executeNonQueryCommand(string sqlCommand, ref MySqlException returnEx)
        {
            bool retVal = true;
            //myConnectionString = Properties.Settings.Default.connectionString;
            int temp;

            try
            {
                myTransCommand.CommandText = sqlCommand;
                if (myTransCommand.Connection.State.ToString() != "Open")
                    myTransCommand.Connection.Open();

                temp = myTransCommand.ExecuteNonQuery();

                retVal = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                retVal = false;
                returnEx = ex;
            }

            return retVal;
        }

        public bool dataExist(string sqlCommand)
        {
            if (conn.State.ToString() != "Open")
                mySqlConnect();

            MySqlCommand cmd = new MySqlCommand(sqlCommand, conn);
            
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    return true;
                }

                return false;
            }
        }
    
        public void beginTransaction()
        {
            //myConnectionString = Properties.Settings.Default.connectionString;

            //transConnection = new MySqlConnection(myConnectionString);
            //setConfigFileConnectionFromTable();
            transConnection = new MySqlConnection(configFileConnectionString);
            transConnection.Open();

            myTransCommand = transConnection.CreateCommand();

            // Start a local transaction
            myTrans = transConnection.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            myTransCommand.Connection = transConnection;
            myTransCommand.Transaction = myTrans;
        }

        public void rollBack(ref MySqlException returnEx)
        {
            try 
            { 
                myTrans.Rollback();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                returnEx = ex;
            }
        }

        public void rollBack()
        {
                myTrans.Rollback();
        }

        public MySqlConnection getMyTransConnection()
        {
            return myTrans.Connection;
        }

        public void commit()
        {
            myTrans.Commit();
        }

        public int getUserAccessRight(int moduleID, int groupID)
        {
            int result = 0;

            result = Convert.ToInt32(getDataSingleValue("SELECT IFNULL(USER_ACCESS_OPTION, 0) FROM USER_ACCESS_MANAGEMENT WHERE MODULE_ID = " + moduleID + " AND GROUP_ID = " + groupID));

            return result;
        }


    }
}
