using System;
using System.Collections.Generic;

namespace ArquivoDefinitivo.Common.Framework.CustomExceptions
{
    public class PersistenceException : Exception
    {
        public string DbErrorMessage { get; set; }
        public Exception OriginalException { get; set; }
        public List<EntityTracker> Entries { get; set; }

        public PersistenceException(Exception originalException, List<EntityTracker> tracker)
        {
            OriginalException = originalException;

            Entries = tracker;
        }

        public PersistenceException(Exception originalException, List<EntityTracker> tracker, string errorMessage)
        {
            OriginalException = originalException;

            Entries = tracker;

            DbErrorMessage = errorMessage;
        }
    }
}
