namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFree, DurationInMonths, DiscountRate, Name) VALUES (4, 30, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
