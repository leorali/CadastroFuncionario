namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStringSexo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionario", "Sexo", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcionario", "Sexo");
        }
    }
}
