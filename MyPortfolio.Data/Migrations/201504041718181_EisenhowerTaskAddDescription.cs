namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EisenhowerTaskAddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EisenhowerTasks", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EisenhowerTasks", "Description");
        }
    }
}
