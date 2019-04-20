using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System;

namespace _SqlHelper
{
    public class SqlHelper
    {
        #region Connection String
        static SqlConnection CONNECTION = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        #endregion Connection String

        #region Reset Connection
        static void ResetConnection()
        {
            if (CONNECTION.State != ConnectionState.Open)
            {
                CONNECTION.Open();
            }
        }

       
        #endregion Reset Connection

        public SqlConnection GetConnection { get { return CONNECTION; } }

        #region Execute Procedure
        protected static SqlCommand ExecuteProcedure(string ProcedureName, SqlParameter[] param, bool AddOutputParameters)
        {
            try
            {
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                COMMAND.Parameters.AddRange(param);
                if (AddOutputParameters == true)
                {
                    COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                    COMMAND.Parameters.Add("@OUTMESSAGE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                }
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                return COMMAND;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected DataTable ExecuteProcedureReturnDataTable(string ProcedureName, string[,] ParamValue)
        {
            SqlCommand COMMAND = new SqlCommand();
            COMMAND.CommandText = ProcedureName;
            SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
            COMMAND.Connection = MYCON;
            COMMAND.CommandTimeout = 0;
            COMMAND.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
            }
            COMMAND.Parameters.AddRange(param);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(COMMAND);
            da.Fill(dt);
            return dt;
        }
        protected static SqlCommand ExecuteProcedure(string ProcedureName, string[,] ParamValue, bool AddOutputParameters)
        {
            try
            {
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
                }
                COMMAND.Parameters.AddRange(param);
                if (AddOutputParameters == true)
                {
                    COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                    COMMAND.Parameters.Add("@OUTMESSAGE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                }
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                return COMMAND;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Execute Procedure

        #region Execute Procedure Detailed
        public static MEMBERS.SQLReturnValue ExecuteProcWithMessage(string ProcedureName, string[,] ParamValue, bool AddOutputParameters)
        {
            try
            {
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
                }
                COMMAND.Parameters.AddRange(param);
                if (AddOutputParameters == true)
                {
                    COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                    COMMAND.Parameters.Add("@OUTMESSAGE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                }
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                MEMBERS.SQLReturnValue M = new MEMBERS.SQLReturnValue();
                M.MessageFromSQL = COMMAND.Parameters["@OUTMESSAGE"].Value.ToString();
                M.ValueFromSQL = int.Parse(COMMAND.Parameters["@OUTVAL"].Value.ToString());
                return M;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static MEMBERS.SQLReturnValue ExecuteProcWithMessageValue(string ProcedureName, string[,] ParamValue, bool AddOutputParameters)
        {
            try
            {
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
                }
                COMMAND.Parameters.AddRange(param);
                if (AddOutputParameters == true)
                {

                    COMMAND.Parameters.Add("@OUTMESSAGE", SqlDbType.VarChar, 5000).Direction = ParameterDirection.Output;
                    COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                }
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                MEMBERS.SQLReturnValue M = new MEMBERS.SQLReturnValue();
                M.MessageFromSQL = COMMAND.Parameters["@OUTMESSAGE"].Value.ToString();
                M.ValueFromSQL = int.Parse(COMMAND.Parameters["@OUTVAL"].Value.ToString());
                return M;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static MEMBERS.SQlReturnInteger ExecuteProcedureReturnInteger(string ProcedureName, SqlParameter[] param)
        {
            try
            {
                MEMBERS.SQlReturnInteger returnval = new MEMBERS.SQlReturnInteger();
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                COMMAND.Parameters.AddRange(param);
                ///Adds the output parameter
                COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                ///Retrive value from output parameters to return value structure.
                returnval.ValueFromSQL = int.Parse(COMMAND.Parameters["@OUTVAL"].Value.ToString());


                return returnval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static MEMBERS.SQLReturnValue ExecuteProcWithMessageValue2(string ProcedureName, string[,] ParamValue, bool AddOutputParameters)
        {
            try
            {
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
                }
                COMMAND.Parameters.AddRange(param);
                if (AddOutputParameters == true)
                {
                    COMMAND.Parameters.Add("@OUTMESSAGE1", SqlDbType.VarChar, 5000).Direction = ParameterDirection.Output;
                    COMMAND.Parameters.Add("@OUTMESSAGE", SqlDbType.VarChar, 5000).Direction = ParameterDirection.Output;
                    COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                }
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                MEMBERS.SQLReturnValue M = new MEMBERS.SQLReturnValue();
                M.MessageFromSQL1 = COMMAND.Parameters["@OUTMESSAGE1"].Value.ToString();
                M.MessageFromSQL = COMMAND.Parameters["@OUTMESSAGE"].Value.ToString();
                M.ValueFromSQL = int.Parse(COMMAND.Parameters["@OUTVAL"].Value.ToString());
                return M;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static MEMBERS.SQLReturnValue ExecuteProcedureReturnValue(string ProcedureName, SqlParameter[] param)
        {
            try
            {
                MEMBERS.SQLReturnValue returnval = new MEMBERS.SQLReturnValue();
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                COMMAND.Parameters.AddRange(param);
                ///Adds the output parameter
                COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;
                COMMAND.Parameters.Add("@OUTMESSAGE", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                ///Retrive value from output parameters to return value structure.
                returnval.MessageFromSQL = COMMAND.Parameters["@OUTMESSAGE"].Value.ToString();
                returnval.ValueFromSQL = int.Parse(COMMAND.Parameters["@OUTVAL"].Value.ToString());


                return returnval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static MEMBERS.SQlReturnInteger ExecuteProcedureReturnInteger(string ProcedureName, string[,] ParamValue)
        {
            try
            {
                MEMBERS.SQlReturnInteger returnval = new MEMBERS.SQlReturnInteger();
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
                }
                COMMAND.Parameters.AddRange(param);
                ///Adds the output parameter
                COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                ///Retrive value from output parameters to return value structure.
                returnval.ValueFromSQL = int.Parse(COMMAND.Parameters["@OUTVAL"].Value.ToString());

                return returnval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Int32 ExecuteProcedureReturnIntegerComma(string ProcedureName, string[,] ParamValue)
        {
            try
            {
                //MEMBERS.SQlReturnInteger returnval = new MEMBERS.SQlReturnInteger();
                Int32 returnval = 0;
                SqlCommand COMMAND = new SqlCommand();
                COMMAND.CommandText = ProcedureName;
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                COMMAND.Connection = MYCON;
                COMMAND.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
                for (int i = 0; i < param.Length; i++)
                {
                    param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
                }
                COMMAND.Parameters.AddRange(param);
                ///Adds the output parameter
                COMMAND.Parameters.Add("@OUTVAL", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                COMMAND.ExecuteNonQuery();
                MYCON.Close();
                ///Retrive value from output parameters to return value structure.
                returnval = int.Parse(COMMAND.Parameters["@OUTVAL"].Value.ToString());

                return returnval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static SqlParameter[] AddParameterAndExecute(string[,] ParamValue)
        {
            SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
            }
            return param;
        }
        #endregion Execute Procedure Detailed

        #region Get Data In Data Table & Data Set
        protected static DataTable ExecuteProcedure(string ProcedureName, SqlParameter[] param)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(ExecuteProcedure(ProcedureName, param, false));
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static DataSet ExecuteProcedureDS(string ProcedureName, SqlParameter[] param)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(ExecuteProcedure(ProcedureName, param, false));
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected static DataTable ExecuteQuery(string Query)
        {
            try
            {
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);

                SqlDataAdapter da = new SqlDataAdapter(Query, MYCON);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDataUsingQuery(string Query)
        {
            try
            {
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter(Query, MYCON);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet GetDataUsingQueryDS(string Query)
        {
            try
            {
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter(Query, MYCON);
                DataSet dt = new DataSet();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDataUsingQuery(SqlCommand cmd)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ExecuteProcedureWithReturnDatatable(string ProcedureName, SqlParameter[] param)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(ExecuteProcedure(ProcedureName, param, false));
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Get Data In Data Table & Data Set

        #region Direct Fire Query
        public static int DML(string q)
        {
            int i = 0;
            try
            {
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                SqlCommand cmd = new SqlCommand(q, MYCON);
                i = cmd.ExecuteNonQuery();
                MYCON.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return i;
        }
        public static int DML(SqlCommand cmd)
        {
            int i = 0;
            try
            {
                SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
                if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
                i = cmd.ExecuteNonQuery();
                MYCON.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return i;
        }
        #endregion Direct Fire Query

        #region Pagging Related
        public static DataTable PaggingData(Int32 PageNo, Int32 PageSize, ref Int32 TotalRecords, string ProcedureName, string[,] ParamValue)
        {
            SqlConnection MYCON = new SqlConnection(CONNECTION.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcedureName;
            cmd.Connection = MYCON;

            cmd.Parameters.AddWithValue("@PageIndex", PageNo);
            cmd.Parameters.AddWithValue("@PageSize", PageSize);

            SqlParameter[] param = new SqlParameter[ParamValue.GetUpperBound(0) + 1];
            for (int i = 0; i < param.Length; i++)
            {
                param[i] = new SqlParameter("@" + ParamValue[i, 0].ToString(), ParamValue[i, 1].ToString());
            }
            cmd.Parameters.AddRange(param);

            cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Direction = ParameterDirection.Output;

            if (MYCON.State != ConnectionState.Open) { MYCON.Open(); }
            SqlDataAdapter dGet = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dGet.Fill(dt);
            TotalRecords = int.Parse(cmd.Parameters["@RecordCount"].Value.ToString());
            MYCON.Close();
            return dt;
        }
        #endregion Pagging Related
    }
}