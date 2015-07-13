using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using Protiviti.Data.Logging;

namespace Protiviti.Boilerplate.Server.Logging
{
    public class EFDbLogFormatter : DatabaseLogFormatter
    {
        public EFDbLogFormatter(DbContext context, Action<string> writeAction)
            : base(context, writeAction)
        {
        }

        public override void LogCommand<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
            Write(string.Format(
                "Context '{0}' is executing command '{1}'{2}",
                Context.GetType().Name,
                command.CommandText.Replace(Environment.NewLine, ""),
                Environment.NewLine));
        }

        public override void LogResult<TResult>(
            DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
        {
        }
    }
}