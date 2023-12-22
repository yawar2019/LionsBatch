namespace CodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "DeptId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeModels", "DeptId");
        }
    }
}
