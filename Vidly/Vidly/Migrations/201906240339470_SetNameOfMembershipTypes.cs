namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Names = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Names = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET Names = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET Names = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
