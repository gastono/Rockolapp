namespace Rocolapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScreenCodeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Screen", "ScreenCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Screen", "ScreenCode");
        }
    }
}
