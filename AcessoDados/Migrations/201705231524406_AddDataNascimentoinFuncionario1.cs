namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataNascimentoinFuncionario1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Beneficio", "Tipo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Beneficio", "Tipo", c => c.String());
        }
    }
}
