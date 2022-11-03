using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PHCleanArchSample.Infra.Data.Migrations
{
    public partial class InsertNoDBviaMigrationSample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[Category]
                                        ([Name])
                                    VALUES
                                        ('Notebooks')");

            migrationBuilder.Sql(@"INSERT INTO [dbo].[Product] ([Name],[Description],[Price] ,[Stock] ,[Image],[CategoryId])
                                    VALUES
                                        ('Ideapad','Notebook bom'
                                        ,3500
                                        ,23
                                        ,'ideapad.jpg'
                                        ,1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
