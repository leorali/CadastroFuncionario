namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeArea = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCargo = c.String(nullable: false),
                        IdArea = c.Int(nullable: false),
                        Area_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.Area_id)
                .Index(t => t.Area_id);
            
            CreateTable(
                "dbo.Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 120),
                        Cpf = c.String(nullable: false, maxLength: 11),
                        IdEndereco = c.Int(nullable: false),
                        IdCargo = c.Int(nullable: false),
                        IdGestor = c.Int(nullable: false),
                        Cargo_Id = c.Int(),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cargo", t => t.Cargo_Id)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id)
                .Index(t => t.Cargo_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.FuncionarioBeneficio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IdFuncionario = c.Int(nullable: false),
                        IdBeneficio = c.Int(nullable: false),
                        Funcionario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Funcionario", t => t.Funcionario_Id)
                .Index(t => t.Funcionario_Id);
            
            CreateTable(
                "dbo.Beneficio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false),
                        Cep = c.Int(nullable: false),
                        Complemento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BeneficioFuncionarioBeneficio",
                c => new
                    {
                        Beneficio_Id = c.Int(nullable: false),
                        FuncionarioBeneficio_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Beneficio_Id, t.FuncionarioBeneficio_id })
                .ForeignKey("dbo.Beneficio", t => t.Beneficio_Id, cascadeDelete: true)
                .ForeignKey("dbo.FuncionarioBeneficio", t => t.FuncionarioBeneficio_id, cascadeDelete: true)
                .Index(t => t.Beneficio_Id)
                .Index(t => t.FuncionarioBeneficio_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Funcionario", "Endereco_Id", "dbo.Endereco");
            DropForeignKey("dbo.Cargo", "Area_id", "dbo.Area");
            DropForeignKey("dbo.Funcionario", "Cargo_Id", "dbo.Cargo");
            DropForeignKey("dbo.FuncionarioBeneficio", "Funcionario_Id", "dbo.Funcionario");
            DropForeignKey("dbo.BeneficioFuncionarioBeneficio", "FuncionarioBeneficio_id", "dbo.FuncionarioBeneficio");
            DropForeignKey("dbo.BeneficioFuncionarioBeneficio", "Beneficio_Id", "dbo.Beneficio");
            DropIndex("dbo.BeneficioFuncionarioBeneficio", new[] { "FuncionarioBeneficio_id" });
            DropIndex("dbo.BeneficioFuncionarioBeneficio", new[] { "Beneficio_Id" });
            DropIndex("dbo.FuncionarioBeneficio", new[] { "Funcionario_Id" });
            DropIndex("dbo.Funcionario", new[] { "Endereco_Id" });
            DropIndex("dbo.Funcionario", new[] { "Cargo_Id" });
            DropIndex("dbo.Cargo", new[] { "Area_id" });
            DropTable("dbo.BeneficioFuncionarioBeneficio");
            DropTable("dbo.Endereco");
            DropTable("dbo.Beneficio");
            DropTable("dbo.FuncionarioBeneficio");
            DropTable("dbo.Funcionario");
            DropTable("dbo.Cargo");
            DropTable("dbo.Area");
        }
    }
}
