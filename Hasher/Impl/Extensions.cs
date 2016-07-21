using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MediaDatabase.Hasher
{
    static class Extensions
    {
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Does not apply to target of extension method.")]
        public static void Start(this IEnumerable<Task> tasks)
        {
            foreach (var task in tasks)
                if (null != task && task.Status == TaskStatus.Created)
                    task.Start();
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Does not apply to target of extension method.")]
        public static void Enqueue<T>(this ConcurrentQueue<T> queue, IEnumerable<T> items)
        {
            if (null == items)
                return;

            foreach (var item in items)
                queue.Enqueue(item);
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Does not apply to target of extension method.")]
        public static IDbConnection CreateConnection(this DbProviderFactory factory, string connectionString)
        {
            var conn = factory.CreateConnection();
            conn.ConnectionString = connectionString;
            return conn;
        }

        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "Does not apply to target of extension method.")]
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities",
            Justification = "Does not apply to generic extension methods.")]
        public static IDbCommand CreateCommand(this IDbConnection conn, CommandType commandType, string commandText)
        {
            var cmd = conn.CreateCommand();
            try
            {
                cmd.CommandType = commandType;
                cmd.CommandText = commandText;
                return cmd;
            }
            catch
            {
                cmd.Dispose();
                throw;
            }
        }

        public static IDbDataParameter CreateInputParameter(this IDbCommand cmd, string parameterName, object value)
        {
            return CreateParameter(cmd, parameterName, ParameterDirection.Input, value);
        }

        public static IDbDataParameter CreateOutputParameter(this IDbCommand cmd, string parameterName, DbType dbType)
        {
            var p = CreateParameter(cmd, parameterName, ParameterDirection.Output);
            p.DbType = dbType;
            return p;
        }

        public static IDbDataParameter CreateParameter(this IDbCommand cmd, string parameterName, ParameterDirection direction)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = parameterName;
            p.Direction = direction;
            return p;
        }

        public static IDbDataParameter CreateParameter(this IDbCommand cmd, string parameterName, ParameterDirection direction, object value)
        {
            var p = CreateParameter(cmd, parameterName, direction);
            p.Value = value;
            return p;
        }

        public static string ToHex(this byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}
