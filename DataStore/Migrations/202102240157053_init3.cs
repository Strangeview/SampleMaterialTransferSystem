namespace DataStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransmitCommands", "Priority", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransmitCommands", "Priority");
        }
    }
}
