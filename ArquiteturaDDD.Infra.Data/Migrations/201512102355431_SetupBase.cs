namespace ArquiteturaDDD.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Observacao = c.String(maxLength: 300, unicode: false),
                        DtInc = c.DateTime(),
                        DtAlt = c.DateTime(),
                        StatusDbAuditTrail = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoa");
        }
    }
}
