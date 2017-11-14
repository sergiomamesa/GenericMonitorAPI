namespace GenericMonitorAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_RemoveUsersFromRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            AddColumn("dbo.Roles", "User_Id", c => c.Int());
            CreateIndex("dbo.Roles", "User_Id");
            AddForeignKey("dbo.Roles", "User_Id", "dbo.Users", "Id");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Role_Id });
            
            DropForeignKey("dbo.Roles", "User_Id", "dbo.Users");
            DropIndex("dbo.Roles", new[] { "User_Id" });
            DropColumn("dbo.Roles", "User_Id");
            CreateIndex("dbo.UserRoles", "Role_Id");
            CreateIndex("dbo.UserRoles", "User_Id");
            AddForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRoles", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
