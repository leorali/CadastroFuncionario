namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTypeCEP : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Endereco", "Cep", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Endereco", "Cep", c => c.Int(nullable: false));
        }
    }
}
