namespace SoHot_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTableRoomStatus : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoomStatus", "ID", "dbo.Rooms");
            DropIndex("dbo.RoomStatus", new[] { "ID" });
            DropTable("dbo.RoomStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoomStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.RoomStatus", "ID");
            AddForeignKey("dbo.RoomStatus", "ID", "dbo.Rooms", "ID");
        }
    }
}
