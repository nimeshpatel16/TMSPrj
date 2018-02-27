using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace TMS.DataAccessLayer
{
    public class SqlHelper
    {
        string strConnectionString = ConfigurationManager.ConnectionStrings["TMSConnectionString"].ConnectionString;
        SqlConnection sqlcon;
        SqlCommand sqlcmd;
        DataSet ds;
        SqlDataReader sqlReader;
        DataTable dt;

        public ArrayList paramList = new ArrayList();

        public SqlHelper()
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = strConnectionString;
        }

        public SqlHelper(string strConnectionString)
        {
            sqlcon = new SqlConnection();
            sqlcon.ConnectionString = strConnectionString;
        }

        void OpenConnection()
        {
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {

            }

        }

        public void AddParameter(IDataParameter param)
        {
            sqlcmd.Parameters.Add(param);
        }
        public void AddParameter(string paramname, object paramvalue)
        {
            Parameter buildParameter = null;
            buildParameter = new Parameter(paramname, paramvalue);
            paramList.Add(buildParameter);
        }
        public void CloseConnection()
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                try
                {
                    sqlcon.Close();
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        #region DataTable Method
        public DataTable ExecuteDataTable(string strSpName, SqlParameter[] arrSqlParam)
        {
            try
            {
                OpenConnection();
                dt = new DataTable();
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;

                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);

                SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd);
                sqladp.Fill(dt);
                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region DataSet Methods
        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            try
            {
                OpenConnection();
                DataSet ds = new DataSet();
                cmd.Connection = sqlcon;
                SqlDataAdapter sqladp = new SqlDataAdapter(cmd);
                sqladp.Fill(ds);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet ExecuteDataSet(string strSpName, SqlParameter[] arrSqlParam)
        {
            try
            {
                OpenConnection();
                ds = new DataSet();
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;

                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);

                SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd);
                sqladp.Fill(ds);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (sqlcmd != null)
                {
                    sqlcmd.Parameters.Clear();
                }
                CloseConnection();
            }
        }

        public DataSet ExecuteDataSet(string strSpName, SqlParameter[] arrSqlParam, int timeOutInSeconds)
        {
            try
            {
                OpenConnection();
                ds = new DataSet();
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (timeOutInSeconds >= 0) // IA: Allow for no timeout
                {
                    sqlcmd.CommandTimeout = timeOutInSeconds;
                }
                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);


                SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd);
                sqladp.Fill(ds);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (sqlcmd != null)
                {
                    sqlcmd.Parameters.Clear();
                }
                CloseConnection();
            }
        }

        public DataSet ExecuteDataSet(string strSql)
        {
            try
            {
                OpenConnection();
                ds = new DataSet();
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = strSql;

                SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd);
                sqladp.Fill(ds);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet ExecuteDataSet(string strSql, int timeOutInSec)
        {
            try
            {
                OpenConnection();
                ds = new DataSet();
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = strSql;
                sqlcmd.CommandTimeout = timeOutInSec;

                SqlDataAdapter sqladp = new SqlDataAdapter(sqlcmd);
                sqladp.Fill(ds);
                return ds;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }


        /// <summary>
        /// HandleDateTime : to handle DateTime?
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>DateTime?</returns>
        public static DateTime? HandleDateTime(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(obj);
            }
        }
        public static Double HandleDouble(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }
        /// <summary>
        /// HandleString : to handle null/string
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>string</returns>
        public static string HandleString(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return string.Empty;
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// HandleString : to handle null/string
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>string</returns>
        public static string HandleNullableString(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return obj.ToString();
            }
        }

        /// <summary>
        /// HandleNullableInt : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int?</returns>
        public static int? HandleNullableInt(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// HandleInt : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int</returns>
        public static int HandleInt(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// HandleNullableDecimal : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>decimal?</returns>
        public static decimal? HandleNullableDecimal(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// HandleDecimal : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>decimal</returns>
        public static decimal HandleDecimal(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(obj);
            }
        }

        /// <summary>
        /// HandleNullbleBool : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int</returns>
        public static bool? HandleNullbleBool(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return null;
            }
            else
            {
                return Convert.ToBoolean(obj);
            }
        }

        /// <summary>
        /// HandleNullbleBool : to handle null/int
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>int</returns>
        public static bool HandleBool(object obj)
        {
            if (Convert.IsDBNull(obj))
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(obj);
            }
        }

        #endregion

        #region ExecuteScalar Methods
        public Object ExecuteScalar(string strSpName, SqlParameter[] arrSqlParam)
        {
            try
            {
                OpenConnection();
                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                //US-66840 Sonar Qube Added {} to if condition SPRINT 1.10.19
                if (arrSqlParam != null)
                {
                    sqlcmd.Parameters.AddRange(arrSqlParam);
                }
                object obj = sqlcmd.ExecuteScalar();

                return obj;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region DataReader Methods

        public SqlDataReader ExecuteDataReader(SqlCommand cmd)
        {
            SqlDataReader dr;

            try
            {
                OpenConnection();

                sqlcmd = cmd;
                sqlcmd.Connection = sqlcon;

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception exp)
            {
                CloseConnection();
                throw exp;
            }

        }

        /// <summary>
        /// ExecuteDataReader
        /// </summary>
        /// <param name="strSpName">string</param>
        /// <param name="arrSqlParam">SqlParameter[]</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteDataReader(string strSpName, SqlParameter[] arrSqlParam)
        {
            return ExecuteDataReader(strSpName, arrSqlParam, 0);
        }

        /// <summary>
        /// ExecuteDataReader
        /// </summary>
        /// <param name="strSpName">string</param>
        /// <param name="arrSqlParam">v</param>
        /// <param name="timeOutInSeconds">timeOutInSeconds</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteDataReader(string strSpName, SqlParameter[] arrSqlParam, int timeOutInSeconds)
        {
            SqlDataReader dr;

            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (timeOutInSeconds > 0)
                {
                    sqlcmd.CommandTimeout = timeOutInSeconds;
                }
                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception exp)
            {
                CloseConnection();
                throw exp;
            }
        }

        public DataTable ExecuteDataReaderAndReturnDataTable(string strSpName, SqlParameter[] arrSqlParam)
        {
            SqlDataReader dr = null;
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                //US-66840 Sonar Qube Added {} to if condition SPRINT 1.10.19
                if (arrSqlParam != null)
                {
                    sqlcmd.Parameters.AddRange(arrSqlParam);
                }
                dr = sqlcmd.ExecuteReader();
                dt.Load(dr);

                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
                CloseConnection();
            }
        }

        public DataTable ExecuteDataReaderAndReturnDataTable(string strSpName, SqlParameter[] arrSqlParam, int timeOutInSeconds)
        {
            SqlDataReader dr = null;
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (timeOutInSeconds > 0)
                {
                    sqlcmd.CommandTimeout = timeOutInSeconds;
                }
                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);

                dr = sqlcmd.ExecuteReader();
                dt.Load(dr);

                return dt;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                    dr.Dispose();
                }
                CloseConnection();
            }
        }

        public SqlDataReader ExecuteDataReader(string strSql)
        {
            SqlDataReader dr;

            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = strSql;

                dr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception exp)
            {
                CloseConnection();
                throw exp;
            }
        }


        public int ExecuteNonQuery(string strSpName, SqlParameter[] arrSqlParam)
        {

            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                //US-66840 Sonar Qube Added {} to if condition SPRINT 1.10.19
                if (arrSqlParam != null)
                {
                    sqlcmd.Parameters.AddRange(arrSqlParam);
                }
                int iRowsAffected = sqlcmd.ExecuteNonQuery();

                return iRowsAffected;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ExecuteNonQuery(string strSpName, SqlParameter[] arrSqlParam, int timeOutInSeconds)
        {

            try
            {
                OpenConnection();

                sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcon;
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = strSpName;
                if (timeOutInSeconds > 0)
                {
                    sqlcmd.CommandTimeout = timeOutInSeconds;
                }
                if (arrSqlParam != null)
                    sqlcmd.Parameters.AddRange(arrSqlParam);

                int iRowsAffected = sqlcmd.ExecuteNonQuery();

                return iRowsAffected;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        public class Parameter
        {
            public string ParameterName;
            public object ParameterValue;
            public int ParameterSize;
            public ParameterDirection ParameterDirectionUsed;

            /// <summary>
            /// Overloaded constructor of Parameter class
            /// </summary>
            /// <param name="passedParameterName"></param>
            /// <param name="passedValue"></param>
            public Parameter(string passedParameterName, object passedValue)
            {

                ParameterName = passedParameterName;
                ParameterValue = passedValue;
                ParameterDirectionUsed = ParameterDirection.Input;
            }

            /// <summary>
            /// Overloaded constructor of Parameter class
            /// </summary>
            /// <param name="passedParameterName"></param>
            /// <param name="passedValue"></param>
            /// <param name="passedSize"></param>
            public Parameter(string passedParameterName, object passedValue, int passedSize)
            {

                ParameterName = passedParameterName;
                ParameterValue = passedValue;
                ParameterSize = passedSize;
                ParameterDirectionUsed = ParameterDirection.Input;
            }

            /// <summary>
            /// Overloaded constructor of Parameter class
            /// </summary>
            /// <param name="passedParameterName"></param>
            /// <param name="passedValue"></param>
            /// <param name="passedDirection"></param>
            public Parameter(string passedParameterName, object passedValue, ParameterDirection passedDirection)
            {

                ParameterName = passedParameterName;
                ParameterValue = passedValue;
                ParameterDirectionUsed = passedDirection;
            }

            /// <summary>
            /// Constructor of the Parameter class
            /// </summary>
            /// <param name="passedParameterName"></param>
            /// <param name="passedValue"></param>
            /// <param name="passedSize"></param>
            /// <param name="passedDirection"></param>
            public Parameter(string passedParameterName, object passedValue, int passedSize, ParameterDirection passedDirection)
            {
                ParameterName = passedParameterName;
                ParameterValue = passedValue;
                ParameterSize = passedSize;
                ParameterDirectionUsed = passedDirection;
            }
        }
    }
}
