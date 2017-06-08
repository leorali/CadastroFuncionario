namespace AcessoDados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDbModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Funcionario", "Area_id", "dbo.Area");
            DropForeignKey("dbo.FuncionarioBeneficioBeneficio", "FuncionarioBeneficio_id", "dbo.FuncionarioBeneficio");
            DropForeignKey("dbo.FuncionarioBeneficioBeneficio", "Beneficio_Id", "dbo.Beneficio");
            DropForeignKey("dbo.Funcionario", "Beneficio_Id", "dbo.Beneficio");
            DropForeignKey("dbo.FuncionarioBeneficio", "Funcionario_Id", "dbo.Funcionario");
            DropForeignKey("dbo.Cargo", "Area_id", "dbo.Area");
            DropForeignKey("dbo.Funcionario", "Cargo_Id", "dbo.Cargo");
            DropForeignKey("dbo.Funcionario", "Endereco_Id", "dbo.Endereco");
            DropIndex("dbo.Cargo", new[] { "Area_id" });
            DropIndex("dbo.Funcionario", new[] { "Area_id" });
            DropIndex("dbo.Funcionario", new[] { "Beneficio_Id" });
            DropIndex("dbo.Funcionario", new[] { "Cargo_Id" });
            DropIndex("dbo.Funcionario", new[] { "Endereco_Id" });
            DropIndex("dbo.FuncionarioBeneficio", new[] { "Funcionario_Id" });
            DropIndex("dbo.FuncionarioBeneficioBeneficio", new[] { "FuncionarioBeneficio_id" });
            DropIndex("dbo.FuncionarioBeneficioBeneficio", new[] { "Beneficio_Id" });
            RenameColumn(table: "dbo.Cargo", name: "Area_id", newName: "AreaId");
            RenameColumn(table: "dbo.Funcionario", name: "Cargo_Id", newName: "CargoId");
            RenameColumn(table: "dbo.Funcionario", name: "Endereco_Id", newName: "EnderecoId");
            CreateTable(
                "dbo.BeneficioFuncionario",
                c => new
                    {
                        Beneficio_Id = c.Int(nullable: false),
                        Funcionario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Beneficio_Id, t.Funcionario_Id })
                .ForeignKey("dbo.Beneficio", t => t.Beneficio_Id, cascadeDelete: true)
                .ForeignKey("dbo.Funcionario", t => t.Funcionario_Id, cascadeDelete: true)
                .Index(t => t.Beneficio_Id)
                .Index(t => t.Funcionario_Id);
            
            AddColumn("dbo.Funcionario", "GestorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cargo", "AreaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Funcionario", "CargoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Funcionario", "EnderecoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cargo", "AreaId");
            CreateIndex("dbo.Funcionario", "EnderecoId");
            CreateIndex("dbo.Funcionario", "CargoId");
            CreateIndex("dbo.Funcionario", "GestorId");
            AddForeignKey("dbo.Funcionario", "GestorId", "dbo.Funcionario", "Id");
            AddForeignKey("dbo.Cargo", "AreaId", "dbo.Area", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Funcionario", "CargoId", "dbo.Cargo", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Funcionario", "EnderecoId", "dbo.Endereco", "Id", cascadeDelete: true);
            DropColumn("dbo.Cargo", "IdArea");
            DropColumn("dbo.Funcionario", "IdEndereco");
            DropColumn("dbo.Funcionario", "IdCargo");
            DropColumn("dbo.Funcionario", "IdGestor");
            DropColumn("dbo.Funcionario", "Area_id");
            DropColumn("dbo.Funcionario", "Beneficio_Id");
            DropTable("dbo.FuncionarioBeneficio");
            DropTable("dbo.FuncionarioBeneficioBeneficio");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FuncionarioBeneficioBeneficio",
                c => new
                    {
                        FuncionarioBeneficio_id = c.Int(nullable: false),
                        Beneficio_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FuncionarioBeneficio_id, t.Beneficio_Id });
            
            CreateTable(
                "dbo.FuncionarioBeneficio",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        IdFuncionario = c.Int(nullable: false),
                        IdBeneficio = c.Int(nullable: false),
                        Funcionario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Funcionario", "Beneficio_Id", c => c.Int());
            AddColumn("dbo.Funcionario", "Area_id", c => c.Int());
            AddColumn("dbo.Funcionario", "IdGestor", c => c.Int(nullable: false));
            AddColumn("dbo.Funcionario", "IdCargo", c => c.Int(nullable: false));
            AddColumn("dbo.Funcionario", "IdEndereco", c => c.Int(nullable: false));
            AddColumn("dbo.Cargo", "IdArea", c => c.Int(nullable: false));
            DropForeignKey("dbo.Funcionario", "EnderecoId", "dbo.Endereco");
            DropForeignKey("dbo.Funcionario", "CargoId", "dbo.Cargo");
            DropForeignKey("dbo.Cargo", "AreaId", "dbo.Area");
            DropForeignKey("dbo.Funcionario", "GestorId", "dbo.Funcionario");
            DropForeignKey("dbo.BeneficioFuncionario", "Funcionario_Id", "dbo.Funcionario");
            DropForeignKey("dbo.BeneficioFuncionario", "Beneficio_Id", "dbo.Beneficio");
            DropIndex("dbo.BeneficioFuncionario", new[] { "Funcionario_Id" });
            DropIndex("dbo.BeneficioFuncionario", new[] { "Beneficio_Id" });
            DropIndex("dbo.Funcionario", new[] { "GestorId" });
            DropIndex("dbo.Funcionario", new[] { "CargoId" });
            DropIndex("dbo.Funcionario", new[] { "EnderecoId" });
            DropIndex("dbo.Cargo", new[] { "AreaId" });
            AlterColumn("dbo.Funcionario", "EnderecoId", c => c.Int());
            AlterColumn("dbo.Funcionario", "CargoId", c => c.Int());
            AlterColumn("dbo.Cargo", "AreaId", c => c.Int());
            DropColumn("dbo.Funcionario", "GestorId");
            DropTable("dbo.BeneficioFuncionario");
            RenameColumn(table: "dbo.Funcionario", name: "EnderecoId", newName: "Endereco_Id");
            RenameColumn(table: "dbo.Funcionario", name: "CargoId", newName: "Cargo_Id");
            RenameColumn(table: "dbo.Cargo", name: "AreaId", newName: "Area_id");
            CreateIndex("dbo.FuncionarioBeneficioBeneficio", "Beneficio_Id");
            CreateIndex("dbo.FuncionarioBeneficioBeneficio", "FuncionarioBeneficio_id");
            CreateIndex("dbo.FuncionarioBeneficio", "Funcionario_Id");
            CreateIndex("dbo.Funcionario", "Endereco_Id");
            CreateIndex("dbo.Funcionario", "Cargo_Id");
            CreateIndex("dbo.Funcionario", "Beneficio_Id");
            CreateIndex("dbo.Funcionario", "Area_id");
            CreateIndex("dbo.Cargo", "Area_id");
            AddForeignKey("dbo.Funcionario", "Endereco_Id", "dbo.Endereco", "Id");
            AddForeignKey("dbo.Funcionario", "Cargo_Id", "dbo.Cargo", "Id");
            AddForeignKey("dbo.Cargo", "Area_id", "dbo.Area", "id");
            AddForeignKey("dbo.FuncionarioBeneficio", "Funcionario_Id", "dbo.Funcionario", "Id");
            AddForeignKey("dbo.Funcionario", "Beneficio_Id", "dbo.Beneficio", "Id");
            AddForeignKey("dbo.FuncionarioBeneficioBeneficio", "Beneficio_Id", "dbo.Beneficio", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FuncionarioBeneficioBeneficio", "FuncionarioBeneficio_id", "dbo.FuncionarioBeneficio", "id", cascadeDelete: true);
            AddForeignKey("dbo.Funcionario", "Area_id", "dbo.Area", "id");
        }
    }
}
