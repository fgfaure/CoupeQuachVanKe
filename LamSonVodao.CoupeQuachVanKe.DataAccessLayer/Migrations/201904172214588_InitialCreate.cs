namespace LamSonVoDao.CoupeQuachVanKe.DataAccessLayer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Competiteurs", "NbPesee", c => c.Int(nullable: false));
            AlterColumn("dbo.ResponsablesClub", "Telephone", c => c.String(maxLength: 14));
            AlterColumn("dbo.ResponsablesCoupe", "Telephone", c => c.String(maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ResponsablesCoupe", "Telephone", c => c.String(maxLength: 14, fixedLength: true));
            AlterColumn("dbo.ResponsablesClub", "Telephone", c => c.String(maxLength: 14, fixedLength: true));
            DropColumn("dbo.Competiteurs", "NbPesee");
        }
    }
}
