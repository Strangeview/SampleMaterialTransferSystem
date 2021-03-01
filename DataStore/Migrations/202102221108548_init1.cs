namespace DataStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransmitCommands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Number = c.String(unicode: false),
                        StartPhysicalAddress = c.String(unicode: false),
                        StartLogicalAddress = c.String(unicode: false),
                        TargetPhysicalAddress = c.String(unicode: false),
                        TargetLogicalAddress = c.String(unicode: false),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        CompleteTime = c.DateTime(nullable: false, precision: 0),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransmitCommands");
        }
    }
}
