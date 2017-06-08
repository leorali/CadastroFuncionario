namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNomeCargotoNomeArea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionario", "Area_id", c => c.Int());
            CreateIndex("dbo.Funcionario", "Area_id");
            AddForeignKey("dbo.Funcionario", "Area_id", "dbo.Area", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "Area_id", "dbo.Area");
            DropIndex("dbo.Funcionario", new[] { "Area_id" });
            DropColumn("dbo.Funcionario", "Area_id");
        }
    }
}
