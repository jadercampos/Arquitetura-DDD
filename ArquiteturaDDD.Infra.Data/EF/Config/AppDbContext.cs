using ArquiteturaDDD.Domain.Entities;
using ArquiteturaDDD.Infra.Data.EF.Map;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace ArquiteturaDDD.Infra.Data.EF.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("ArquiteturaDDD")
        {

        }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PessoaConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DtAlt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DtInc").CurrentValue = DateTime.Now;
                    entry.Property("DtInc").IsModified = false;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DtAlt").CurrentValue = DateTime.Now;
                    entry.Property("DtInc").IsModified = false;
                }
            }
            return base.SaveChanges();
        }


    }
}
