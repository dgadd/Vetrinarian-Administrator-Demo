using System;
using System.IO;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Gaddzeit.VetAdmin.Domain.Entities;
using Gaddzeit.VetAdmin.Shared;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Gaddzeit.VetAdmin.Repository.NHibernateRepositories
{
    public class SessionFactoryBuilder
    {
        private const string SqlLiteFakeDb = "FakeSqlLiteDB.db";

        public ISessionFactory CreateSqlLiteSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                .UsingFile(SqlLiteFakeDb))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Pet>())
                .ExposeConfiguration(BuildSqlLiteSchema)
                .BuildSessionFactory();
        }

        private static void BuildSqlLiteSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(SqlLiteFakeDb))
                File.Delete(SqlLiteFakeDb);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }

        public ISessionFactory CreateSqlServerSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2008
                    .ConnectionString(ApplicationConstants.SqlServerConnectionString)
                    .ShowSql()
                    .ProxyFactoryFactory("NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle") 
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Pet>())
                .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "thread_static"))
                .BuildSessionFactory();
        }
    }
}
