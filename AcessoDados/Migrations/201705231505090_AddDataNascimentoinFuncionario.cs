namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataNascimentoinFuncionario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Funcionario", "DataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Funcionario", "DataNascimento");
        }
    }
}
