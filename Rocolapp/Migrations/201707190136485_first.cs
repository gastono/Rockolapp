namespace Rocolapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RocolappUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Place = c.String(),
                        SpotifyId = c.String(),
                        PlaylistId = c.String(),
                        Token = c.String(),
                        RefreshToken = c.String(),
                        Scope = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Screen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        RocolappUserName = c.String(),
                        SpotifyUserId = c.String(),
                        ConnectionId = c.String(),
                        Connected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Screen");
            DropTable("dbo.RocolappUser");
        }
    }
}
