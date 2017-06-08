namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CPFLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Funcionario", "Cpf", c => c.String(nullable: false, maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Funcionario", "Cpf", c => c.String(nullable: false, maxLength: 11));
        }
    }
}
