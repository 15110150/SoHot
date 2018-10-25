namespace SoHot_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoomType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomTypes", "MaxPeople", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomTypes", "MaxPeople");
        }
    }
}
