namespace FarolVerde.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ocorrencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Ocorrência = c.String(),
                        Código = c.String(),
                        LocaldaOcorrência = c.String(name: "Local da Ocorrência"),
                        AlturaNumérica = c.String(name: "Altura Numérica"),
                        Sentido = c.String(),
                        Pista = c.String(),
                        FaixaOcupação = c.String(name: "Faixa Ocupação"),
                        TotaldeFaixas = c.String(name: "Total de Faixas"),
                        DataHoraChegada = c.DateTime(name: "Data Hora (Chegada)", nullable: false),
                        DataHoraChegadaMan = c.DateTime(name: "Data Hora (Chegada Man )", nullable: false),
                        DataHoraRemSol = c.DateTime(name: "Data Hora (Rem Sol)", nullable: false),
                        DataHoraRemSolMa = c.DateTime(name: "Data Hora (Rem Sol Ma)", nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ocorrencia");
        }
    }
}
