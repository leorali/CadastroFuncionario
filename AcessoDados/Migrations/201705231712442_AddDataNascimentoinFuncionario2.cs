namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataNascimentoinFuncionario2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BeneficioFuncionarioBeneficio", newName: "FuncionarioBeneficioBeneficio");
            DropPrimaryKey("dbo.FuncionarioBeneficioBeneficio");
            AddColumn("dbo.Funcionario", "Beneficio_Id", c => c.Int());
            AddColumn("dbo.Beneficio", "TipoDeBeneficio", c => c.String(nullable: false));
            AddPrimaryKey("dbo.FuncionarioBeneficioBeneficio", new[] { "FuncionarioBeneficio_id", "Beneficio_Id" });
            CreateIndex("dbo.Funcionario", "Beneficio_Id");
            AddForeignKey("dbo.Funcionario", "Beneficio_Id", "dbo.Beneficio", "Id");
            DropColumn("dbo.Beneficio", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Beneficio", "Tipo", c => c.String(nullable: false));
            DropForeignKey("dbo.Funcionario", "Beneficio_Id", "dbo.Beneficio");
            DropIndex("dbo.Funcionario", new[] { "Beneficio_Id" });
            DropPrimaryKey("dbo.FuncionarioBeneficioBeneficio");
            DropColumn("dbo.Beneficio", "TipoDeBeneficio");
            DropColumn("dbo.Funcionario", "Beneficio_Id");
            AddPrimaryKey("dbo.FuncionarioBeneficioBeneficio", new[] { "Beneficio_Id", "FuncionarioBeneficio_id" });
            RenameTable(name: "dbo.FuncionarioBeneficioBeneficio", newName: "BeneficioFuncionarioBeneficio");
        }
    }
}
