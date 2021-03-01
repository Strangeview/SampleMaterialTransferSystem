namespace DataStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransmitCommands", "RailID", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransmitCommands", "RailID");
        }
    }
}
