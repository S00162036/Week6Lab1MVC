namespace S00162036Rad2017Mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "firstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "surName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "surName");
            DropColumn("dbo.AspNetUsers", "firstName");
        }
    }
}
