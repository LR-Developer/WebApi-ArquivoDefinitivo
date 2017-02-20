using ArquivoDefinitivo.Common.Infrastructure.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using ArquivoDefinitivo.Common.Framework.CustomExceptions;
using ArquivoDefinitivo.Common.Domain.Contracts;
using System.Data.SqlClient;

namespace ArquivoDefinitivo.Common.Infrastructure.Data
{
    public class ArquivoDefinitivoCommonDbContext : DbContext, IDbContext
    {
        //private readonly static LogOracleCommandInterceptor interceptor = new LogOracleCommandInterceptor();

        public ArquivoDefinitivoCommonDbContext(string connectionString)
            : base(connectionString)
        {
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;

            //DbInterception.Add(interceptor);
            this.Database.CommandTimeout = 180;
        }

        public IEnumerable<string> GetPropertyKeys<TEntity>()
            where TEntity : class
        {
            ObjectContext objectContext = ((IObjectContextAdapter)this).ObjectContext;

            ObjectSet<TEntity> set = objectContext.CreateObjectSet<TEntity>();

            IEnumerable<string> keyNames = set.EntitySet.ElementType
                                            .KeyMembers
                                            .Select(k => k.Name);

            return keyNames;
        }

        public List<object> GetPropertyKeyValues<TEntity>(TEntity entity)
            where TEntity : class
        {
            IEnumerable<string> keyNames = this.GetPropertyKeys<TEntity>();

            List<object> pksValues = new List<object>();

            foreach (string key in keyNames)
            {
                pksValues.Add(typeof(TEntity).GetProperty(key).GetValue(entity));
            }

            return pksValues;
        }

        public override int SaveChanges()
        {
            // Obter a instância do Contexto
            ObjectContext objectContext = ((IObjectContextAdapter)this).ObjectContext;

            foreach (var changeSet in ChangeTracker.Entries())
            {
                var entity = changeSet.Entity;

                var entityType = entity.GetType();

                if (entityType == null)
                {
                    continue;
                }

                var entityCustomAttributes = TypeDescriptor.GetAttributes(entityType);

                if (entityCustomAttributes == null)
                {
                    continue;
                }

                if (entityCustomAttributes.Count == 0)
                {
                    continue;
                }

                if (changeSet.State != EntityState.Added)
                {
                    continue;
                }
            }

            try
            {
                int returnSave = base.SaveChanges();

                base.ChangeTracker.Entries().ToList().ForEach(i =>
                {
                    i.State = EntityState.Detached;
                });

                return returnSave;
            }
            catch (DbUpdateException err)
            {
                List<EntityTracker> Entries = new List<EntityTracker>();

                foreach (var entry in base.ChangeTracker.Entries())
                {
                    Entries.Add(new EntityTracker
                    {
                        Entity = entry.Entity.GetType().Name,
                        State = entry.State.ToString()
                    });
                }

                Exception inner = err;

                while (inner.InnerException != null)
                {
                    inner = inner.InnerException;
                }

                string erroMessage = inner.Message;

                throw new PersistenceException(err, Entries, erroMessage);
            }
            catch (Exception err)
            {
                List<EntityTracker> Entries = new List<EntityTracker>();

                foreach (var entry in base.ChangeTracker.Entries())
                {
                    Entries.Add(new EntityTracker
                    {
                        Entity = entry.Entity.GetType().Name,
                        State = entry.State.ToString()
                    });
                }

                throw new PersistenceException(err, Entries);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //DbInterception.Remove(interceptor);

                base.Dispose(disposing);
            }
        }

        private void SetParams(IList<IProcParameter> procParams, IEnumerable<SqlParameter> listParams)
        {
            Parallel.ForEach(listParams.Where(p => p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.Output), i =>
            {
                var item = procParams.FirstOrDefault(f => f.Name == i.ParameterName);
                if (i.Value != null)
                    item.SetValue(i.Value);
            });
        }

        private IEnumerable<SqlParameter> GetParams(IList<IProcParameter> listParam)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            foreach (var item in listParam)
                lista.Add((SqlParameter)item.GetParam());
            return lista;
        }

        private string FormatProcCall(string procCall, bool noResult = false)
        {
            if (!noResult)
            {
                if (!procCall.ToUpper().Contains(":RESULT") && procCall.ToUpper().Contains(")") && procCall.ToUpper().Contains(":")) procCall = procCall.Replace(")", ",:RESULT)");
                if (!procCall.ToUpper().Contains(":RESULT") && procCall.ToUpper().Contains(")") && !procCall.ToUpper().Contains(":")) procCall = procCall.Replace(")", ":RESULT)");
                if (!procCall.ToUpper().Contains(":RESULT") && !procCall.ToUpper().Contains(")")) procCall = procCall = procCall + "(:RESULT)";
            }
            if (!procCall.ToUpper().Contains("BEGIN")) procCall = "BEGIN " + procCall;
            if (!procCall.ToUpper().EndsWith(";")) procCall = procCall + "; ";
            if (!procCall.ToUpper().Contains("END;")) procCall = procCall + "END;";

            return procCall;
        }

        private string FormatFuctionCall(string funcCall)
        {
            if (!funcCall.ToUpper().Contains("BEGIN")) funcCall = "BEGIN :result := " + funcCall;
            if (!funcCall.ToUpper().EndsWith(";")) funcCall = funcCall + "; ";
            if (!funcCall.ToUpper().Contains("END;")) funcCall = funcCall + "END;";

            return funcCall;
        }
    }
}
