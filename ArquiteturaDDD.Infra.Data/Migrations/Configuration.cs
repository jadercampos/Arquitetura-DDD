namespace ArquiteturaDDD.Infra.Data.Migrations
{
    using EF.Config;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator(new string[] { "DtInc" }));
        }

        protected override void Seed(AppDbContext context)
        {
        }
    }
    internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        private static string[] GetDateCols { get; set; }
        public CustomSqlServerMigrationSqlGenerator(string[] GetDateColNames) : base()
        {
            GetDateCols = GetDateColNames;
        }
        protected override void Generate(AddColumnOperation addColumnOperation)
        {
            SetGetDateColumn(addColumnOperation.Column);

            base.Generate(addColumnOperation);
        }

        protected override void Generate(CreateTableOperation createTableOperation)
        {

            SetGetDateColumn(createTableOperation.Columns);

            base.Generate(createTableOperation);
        }

        private static void SetGetDateColumn(IEnumerable<ColumnModel> columns)
        {
            foreach (var columnModel in columns)
            {
                SetGetDateColumn(columnModel);
            }
        }

        private static void SetGetDateColumn(PropertyModel column)
        {
            if (GetDateCols != null && GetDateCols.Length > 0 && GetDateCols.Contains(column.Name))
            {
                column.DefaultValueSql = "GETDATE()";
            }
        }
    }
}
