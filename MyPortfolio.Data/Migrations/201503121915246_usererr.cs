namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usererr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Password");
        }
    }
}
