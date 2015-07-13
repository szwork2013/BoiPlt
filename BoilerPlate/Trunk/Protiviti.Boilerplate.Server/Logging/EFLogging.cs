using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace Protiviti.Data.Logging
{
    [EventSource(Name = "EFLogging")]
    public class EFLogging : EventSource
    {

        private static readonly Lazy<EFLogging> Instance = new Lazy<EFLogging>(() => new EFLogging());

        public static EFLogging Logger
        {
            get { return Instance.Value; }
        }

        public static class Keywords
        {
            public const EventKeywords Application = (EventKeywords)1L;
            public const EventKeywords DataAccess = (EventKeywords)2L;
            public const EventKeywords UserInterface = (EventKeywords)4L;
            public const EventKeywords General = (EventKeywords)8L;
        }

        public static class Tasks
        {
            public const EventTask NonQueryExecuted = (EventTask)1;
            public const EventTask ReaderExecuted = (EventTask)2;
            public const EventTask ScalarExecuted = (EventTask)3;
            public const EventTask Tracing = (EventTask)4;
        }

        public static class Opcodes
        {
            public const EventOpcode Start = (EventOpcode)20;
            public const EventOpcode Finish = (EventOpcode)21;
            public const EventOpcode Error = (EventOpcode)22;
            public const EventOpcode Starting = (EventOpcode)23;

            public const EventOpcode QueryStart = (EventOpcode)30;
            public const EventOpcode QueryFinish = (EventOpcode)31;
            public const EventOpcode QueryNoResults = (EventOpcode)32;

            public const EventOpcode CacheQuery = (EventOpcode)40;
            public const EventOpcode CacheUpdate = (EventOpcode)41;
            public const EventOpcode CacheHit = (EventOpcode)42;
            public const EventOpcode CacheMiss = (EventOpcode)43;
        }

        //public static readonly EFLogging Log = new EFLogging();

        #region Methods

        [Event(2001, Level = EventLevel.Informational, Keywords = Keywords.DataAccess, Task = Tasks.NonQueryExecuted, Opcode = Opcodes.QueryFinish, Version = 1)]
        public void NonQueryExecuted(string query)
        {
            if (this.IsEnabled(EventLevel.Informational, Keywords.DataAccess))
            {
                this.WriteEvent(2001, query);
            }
        }

        [Event(2002, Level = EventLevel.Informational, Keywords = Keywords.DataAccess, Task = Tasks.ReaderExecuted, Opcode = Opcodes.QueryFinish, Version = 1)]
        public void ReaderExecuted(string query)
        {
            if (this.IsEnabled(EventLevel.Informational, Keywords.DataAccess))
            {
                this.WriteEvent(2002, query);
            }
        }
        [Event(2003, Level = EventLevel.Informational, Keywords = Keywords.DataAccess, Task = Tasks.ScalarExecuted, Opcode = Opcodes.QueryFinish, Version = 1)]
        public void ScalarExecuted(string query)
        {
            if (this.IsEnabled(EventLevel.Informational, Keywords.DataAccess))
            {
                this.WriteEvent(2003, query);
            }
        }
        [Event(204, Level = EventLevel.Informational, Keywords = Keywords.DataAccess, Task = Tasks.Tracing, Opcode = Opcodes.Finish, Version = 1)]
        public void Log(string query)
        {
            if (this.IsEnabled(EventLevel.Informational, Keywords.DataAccess))
            {
                this.WriteEvent(2003, query);
            }
        }
        #endregion

        [Event(3001, Level = EventLevel.Error, Keywords = Keywords.General, Task = Tasks.Tracing, Opcode = Opcodes.Error, Version = 1)]
        public void Error(string message, Guid id)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(3001, message, id);
            }
        }
        [Event(3002, Level = EventLevel.Warning, Keywords = Keywords.General, Task = Tasks.Tracing, Version = 1)]
        public void Warn(string message)
        {
            if (this.IsEnabled())
            {
                this.WriteEvent(3002, message);
            }
        }
    }
}