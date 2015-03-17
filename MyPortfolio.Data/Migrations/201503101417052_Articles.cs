namespace MyPortfolio.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Articles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArticleCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

			CreateTable (
				"dbo.Articles" ,
				c => new {
					Id = c.Int ( nullable: false , identity: true ) ,
					Name = c.String () ,
					Brief = c.String () ,
					CategoryId = c.Int ( nullable: false ) ,
				} )
				.PrimaryKey ( t => t.Id )
				.ForeignKey ( "dbo.ArticleCategories" , t => t.CategoryId , cascadeDelete: false )
				.Index ( t => t.CategoryId );
            CreateTable(
                "dbo.ArticleParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: false)
                .Index(t => t.ArticleId);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleParts", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.ArticleCategories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.ArticleParts", new[] { "ArticleId" });
            DropTable("dbo.Articles");
            DropTable("dbo.ArticleParts");
            DropTable("dbo.ArticleCategories");
        }
    }
}
