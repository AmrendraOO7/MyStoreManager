using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMControl.Connection
{
    public class Execute
    {
       
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction,
            CommandType commandType, string commandText, IEnumerable<SqlParameter> commandParameters,
            out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (string.IsNullOrEmpty(commandText)) throw new ArgumentNullException(nameof(commandText));

            // If the provided connection is not open, we will open it
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            command.Connection = connection;

            // Set the command text (stored procedure name or SQL statement)
            command.CommandText = commandText;

            // If we were provided a transaction, assign it
            if (transaction != null)
            {
                if (transaction.Connection == null)
                    throw new ArgumentException(
                        @"THE TRANSACTION DECLINED..!!",String.Empty);
                command.Transaction = transaction;
            }

            // Set the command type
            command.CommandType = commandType;

            // Attach the command parameters if they are provided
            if (commandParameters != null) AttachParameters(command, commandParameters);
        }

        private static void AttachParameters(SqlCommand command, IEnumerable<SqlParameter> commandParameters)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (commandParameters == null) return;
            foreach (var p in commandParameters.Where(p => p != null))
            {
                // Check for derived output value with no value assigned
                if ((p.Direction == ParameterDirection.InputOutput ||
                     p.Direction == ParameterDirection.Input) &&
                    p.Value == null)
                    p.Value = DBNull.Value;
                command.Parameters.Add(p);
            }
        }



        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText,
            params SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            // Create a command and prepare it for execution
            try
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters,
                    out var mustCloseConnection);
                cmd.CommandTimeout = 0;
                var rNonQuery = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                if (!mustCloseConnection) return rNonQuery;
                connection.Close();
                return rNonQuery;
            }
            catch (Exception e)
            {
                 MessageBox.Show(e.ToString());
            }

            return 0;
        }
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText,
            params SqlParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            try
            {
                // Create & open a SqlConnection, and dispose of it after we are done
                var connection = new SqlConnection(connectionString);
                connection.Open();
                // Call the overload that takes a connection in place of the connection string
                return ExecuteNonQuery(connection, commandType, commandText, commandParameters);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return 0;
            }
        }

        public static int ExecuteNonQueryResources(SqlConnection connection, CommandType commandType, string commandText,
            params SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            // Create a command and prepare it for execution
            try
            {
                var cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters,
                    out var mustCloseConnection);
                cmd.CommandTimeout = 0;
                var rNonQuery = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                if (!mustCloseConnection) return rNonQuery;
                connection.Close();
                return rNonQuery;
            }
            catch 
            {
               //
            }

            return 0;
        }

        public static int ExecuteNonQueryOnMainResources(string connectionString, CommandType commandType,
            string commandText, params SqlParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return ExecuteNonQueryResources(connection, commandType, commandText, commandParameters);
            }
            catch
            {
                return 0;
            }
        }

        private static DataSet ExecuteDataSet(SqlConnection connection, CommandType commandType, string commandText,
            params SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            try
            {
                // Create a command and prepare it for execution
                var cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, commandType, commandText, commandParameters,
                    out var mustCloseConnection);

                // Create the DataAdapter & DataSet
                var da = new SqlDataAdapter(cmd);
                var ds = new DataSet();

                // Fill the DataSet using default values for DataTable names, etc
                da.Fill(ds);

                // Detach the SqlParameters from the command object, so they can be used again
                cmd.Parameters.Clear();

                if (mustCloseConnection)
                    connection.Close();

                // Return the dataset
                return ds;
            }
            catch 
            {
                return new DataSet();
            }
        }

        private static DataSet ExecuteDataSet(string connectionString, CommandType commandType, string commandText,
            params SqlParameter[] commandParameters)
        {
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            // Create & open a SqlConnection, and dispose of it after we are done
            var connection = new SqlConnection(connectionString);
            connection.Open();

            // Call the overload that takes a connection in place of the connection string
            return ExecuteDataSet(connection, commandType, commandText, commandParameters);
        }

        //private static DataSet ExecuteDataSet(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        //{
        //    if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

        //    var connection = new SqlConnection(connectionString);
        //    var maxAttempts = 3; // Maximum number of attempts to establish connection
        //    var attemptCount = 0;
        //    bool connectionOpened = false;

        //    do
        //    {
        //        try
        //        {
        //            connection.Open();
        //            connectionOpened = true;
        //        }
        //        catch (SqlException ex)
        //        {
        //            if (attemptCount == maxAttempts)
        //            {
        //                throw ex; // Re-throw the exception if we've reached the maximum attempts
        //            }
        //            else
        //            {
        //                attemptCount++;
        //                System.Threading.Thread.Sleep(1000); // Wait for 1 second before trying again
        //            }
        //        }
        //    } while (!connectionOpened);

        //    return ExecuteDataSet(connection, commandType, commandText, commandParameters);
        //}



        // used in creation of database
        public static int ExecuteNonQueryMaster(string QueryText) //Refrence from/*https://www.c-sharpcorner.com/forums/sql-helper-class6*/
        {
            return ExecuteNonQuery(Connection.ConnectionMaster, CommandType.Text, QueryText, null);
        }

        // Used For connection in local database
        public static int ExecuteNonQueryLocalMaster(string QueryText)
        {
            return ExecuteNonQuery(Connection.ConnectionLocalMaster, CommandType.Text, QueryText, null);
        }

        // Used For connection in Main database
        public static int ExecuteNonQueryOnMain(string QueryText)
        {
            return ExecuteNonQuery(Connection.ConnectionMain, CommandType.Text, QueryText, null);
        }

        // Used For connection in Main Database Resources related to main tables
        public static int ExecuteNonQueryOnMainResources(string QueryText)
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteNonQueryOnMainResources(Connection.ConnectionMain, CommandType.Text, QueryText, null);
        }

        //Used For connection of dataset in Main database 
        public static DataSet ExecuteDataSetOnMain(string QueryText)
        {
            return ExecuteDataSet(Connection.ConnectionMain, CommandType.Text, QueryText, null);
        }

        //Used For connection of dataset in Main database (related to login)
        public static DataSet ExecuteDataSetOnMain(string connectionString, CommandType commandType, string commandText)
        {
            return ExecuteDataSet(Connection.ConnectionMain, CommandType.Text, commandText, null);
        }
        //public static DataSet ExecuteDataSetOnMaster(string QueryText)
        //{
        //    // Pass through the call providing null for the set of SqlParameters
        //    return ExecuteDataSet(Connection.ConnectionMaster, CommandType.Text, QueryText, null);
        //}

        //Used For connection of dataset in local database  -- used to check table values
        public static DataSet ExecuteDataSetOnLocalMaster(string QueryText)
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteDataSet(Connection.ConnectionLocalMaster, CommandType.Text, QueryText, null);
        }

        //Used For connection of dataset in local database -- used to return table values
        public static DataSet ExecuteDataSetOnLocalMaster(string connectionString, CommandType commandType, string commandText) 
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteDataSet(connectionString, commandType, commandText, null);
        }

    }
}
