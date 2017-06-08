namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTypeGestorId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Funcionario", new[] { "GestorId" });
            AlterColumn("dbo.Funcionario", "GestorId", c => c.Int());
            CreateIndex("dbo.Funcionario", "GestorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Funcionario", new[] { "GestorId" });
            AlterColumn("dbo.Funcionario", "GestorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Funcionario", "GestorId");
        }
    }
}
