namespace Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentID = c.Int(nullable: false, identity: true),
                        studentName = c.String(nullable: false),
                        studentAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.studentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
