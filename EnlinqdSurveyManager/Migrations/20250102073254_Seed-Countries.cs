using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnlinqdSurveyManager.Migrations
{
    /// <inheritdoc />
    public partial class SeedCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Products = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.Sql(@"
                INSERT INTO Country (Id, CountryCode, CountryName, CurrencyCode) VALUES
                (NEWID(), 'AD', 'Andorra', 'EUR'),
                (NEWID(), 'AE', 'United Arab Emirates', 'AED'),
                (NEWID(), 'AF', 'Afghanistan', 'AFN'),
                (NEWID(), 'AG', 'Antigua and Barbuda', 'XCD'),
                (NEWID(), 'AI', 'Anguilla', 'XCD'),
                (NEWID(), 'AL', 'Albania', 'ALL'),
                (NEWID(), 'AM', 'Armenia', 'AMD'),
                (NEWID(), 'AO', 'Angola', 'AOA'),
                (NEWID(), 'AQ', 'Antarctica', ''),
                (NEWID(), 'AR', 'Argentina', 'ARS'),
                (NEWID(), 'AS', 'American Samoa', 'USD'),
                (NEWID(), 'AT', 'Austria', 'EUR'),
                (NEWID(), 'AU', 'Australia', 'AUD'),
                (NEWID(), 'AW', 'Aruba', 'AWG'),
                (NEWID(), 'AX', 'Åland', 'EUR'),
                (NEWID(), 'AZ', 'Azerbaijan', 'AZN'),
                (NEWID(), 'BA', 'Bosnia and Herzegovina', 'BAM'),
                (NEWID(), 'BB', 'Barbados', 'BBD'),
                (NEWID(), 'BD', 'Bangladesh', 'BDT'),
                (NEWID(), 'BE', 'Belgium', 'EUR'),
                (NEWID(), 'BF', 'Burkina Faso', 'XOF'),
                (NEWID(), 'BG', 'Bulgaria', 'BGN'),
                (NEWID(), 'BH', 'Bahrain', 'BHD'),
                (NEWID(), 'BI', 'Burundi', 'BIF'),
                (NEWID(), 'BJ', 'Benin', 'XOF'),
                (NEWID(), 'BL', 'Saint Barthélemy', 'EUR'),
                (NEWID(), 'BM', 'Bermuda', 'BMD'),
                (NEWID(), 'BN', 'Brunei', 'BND'),
                (NEWID(), 'BO', 'Bolivia', 'BOB'),
                (NEWID(), 'BQ', 'Bonaire', 'USD'),
                (NEWID(), 'BR', 'Brazil', 'BRL'),
                (NEWID(), 'BS', 'Bahamas', 'BSD'),
                (NEWID(), 'BT', 'Bhutan', 'BTN'),
                (NEWID(), 'BV', 'Bouvet Island', 'NOK'),
                (NEWID(), 'BW', 'Botswana', 'BWP'),
                (NEWID(), 'BY', 'Belarus', 'BYR'),
                (NEWID(), 'BZ', 'Belize', 'BZD'),
                (NEWID(), 'CA', 'Canada', 'CAD'),
                (NEWID(), 'CC', 'Cocos [Keeling] Islands', 'AUD'),
                (NEWID(), 'CD', 'Democratic Republic of the Congo', 'CDF'),
                (NEWID(), 'CF', 'Central African Republic', 'XAF'),
                (NEWID(), 'CG', 'Republic of the Congo', 'XAF'),
                (NEWID(), 'CH', 'Switzerland', 'CHF'),
                (NEWID(), 'CI', 'Ivory Coast', 'XOF'),
                (NEWID(), 'CK', 'Cook Islands', 'NZD'),
                (NEWID(), 'CL', 'Chile', 'CLP'),
                (NEWID(), 'CM', 'Cameroon', 'XAF'),
                (NEWID(), 'CN', 'China', 'CNY'),
                (NEWID(), 'CO', 'Colombia', 'COP'),
                (NEWID(), 'CR', 'Costa Rica', 'CRC'),
                (NEWID(), 'CU', 'Cuba', 'CUP'),
                (NEWID(), 'CV', 'Cape Verde', 'CVE'),
                (NEWID(), 'CW', 'Curacao', 'ANG'),
                (NEWID(), 'CX', 'Christmas Island', 'AUD'),
                (NEWID(), 'CY', 'Cyprus', 'EUR'),
                (NEWID(), 'CZ', 'Czechia', 'CZK'),
                (NEWID(), 'DE', 'Germany', 'EUR'),
                (NEWID(), 'DJ', 'Djibouti', 'DJF'),
                (NEWID(), 'DK', 'Denmark', 'DKK'),
                (NEWID(), 'DM', 'Dominica', 'XCD'),
                (NEWID(), 'DO', 'Dominican Republic', 'DOP'),
                (NEWID(), 'DZ', 'Algeria', 'DZD'),
                (NEWID(), 'EC', 'Ecuador', 'USD'),
                (NEWID(), 'EE', 'Estonia', 'EUR'),
                (NEWID(), 'EG', 'Egypt', 'EGP'),
                (NEWID(), 'EH', 'Western Sahara', 'MAD'),
                (NEWID(), 'ER', 'Eritrea', 'ERN'),
                (NEWID(), 'ES', 'Spain', 'EUR'),
                (NEWID(), 'ET', 'Ethiopia', 'ETB');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
