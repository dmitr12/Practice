namespace Pract.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedArticleModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "FirstStr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "FirstStr");
        }
    }
}
