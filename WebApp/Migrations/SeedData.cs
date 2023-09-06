using Microsoft.EntityFrameworkCore;
using WebApp.Data.Entities;

namespace WebApp.Migrations
{
    public static class SeedData
    {
        private static readonly List<Organisation> Organisations = new List<Organisation>
        {
            new Organisation
            {
                OrganisationName = "Barclays UK PLC", OrganisationNumber = "09740322",
                AddressLine1 = "1 Churchill Place", AddressLine2 = "nan", AddressLine3 = "nan",
                AddressLine4 = "nan", Town = "London", Postcode = "E14 5HP"
            },
            new Organisation
            {
                OrganisationName = "HSBC BANK PLC", OrganisationNumber = "00014259",
                AddressLine1 = "8 Canada Square", AddressLine2 = "nan", AddressLine3 = "nan", AddressLine4 = "nan",
                Town = "London", Postcode = "E14 5HQ"
            },
            new Organisation
            {
                OrganisationName = "LLOYDS BANK PLC", OrganisationNumber = "00002065",
                AddressLine1 = "25 Gresham Street", AddressLine2 = "nan", AddressLine3 = "nan",
                AddressLine4 = "nan", Town = "London", Postcode = "EC2V 7HN"
            },
            new Organisation
            {
                OrganisationName = "TSB BANK PLC", OrganisationNumber = "SC095237",
                AddressLine1 = "Henry Duncan House", AddressLine2 = "120 George Street", AddressLine3 = "nan",
                AddressLine4 = "nan", Town = "Edinburgh", Postcode = "EH2 4LH"
            },
            new Organisation
            {
                OrganisationName = "CLYDESDALE BANK PLC", OrganisationNumber = "SC001111",
                AddressLine1 = "30 St Vincent Place", AddressLine2 = "nan", AddressLine3 = "nan",
                AddressLine4 = "nan", Town = "Glasgow", Postcode = "G1 2HL"
            },
            new Organisation
            {
                OrganisationName = "STANDARD CHARTERED PLC", OrganisationNumber = "00966425",
                AddressLine1 = "1 Basinghall Avenue", AddressLine2 = "nan", AddressLine3 = "nan",
                AddressLine4 = "nan", Town = "London", Postcode = "EC2V 5DD"
            },
            new Organisation
            {
                OrganisationName = "BANK OF SCOTLAND PLC", OrganisationNumber = "SC327000",
                AddressLine1 = "The Mound", AddressLine2 = "nan", AddressLine3 = "nan", AddressLine4 = "nan",
                Town = "Edinburgh", Postcode = "EH1 1YZ"
            },
        };

        private static readonly IList<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, OrganisationNumber = "09740322", FirstName = "Janet", LastName = "Smith" },
            new Employee { Id = 2, OrganisationNumber = "09740322", FirstName = "Frank", LastName = "Bloswick" },
            new Employee { Id = 3, OrganisationNumber = "09740322", FirstName = "Tonya", LastName = "Bazinaw" },
            new Employee { Id = 4, OrganisationNumber = "09740322", FirstName = "Mike", LastName = "St. Onge" },
            new Employee { Id = 5, OrganisationNumber = "09740322", FirstName = "Jackie", LastName = "Jones" },
            new Employee { Id = 6, OrganisationNumber = "09740322", FirstName = "Darren", LastName = "Tillbrooke" },
            new Employee { Id = 7, OrganisationNumber = "09740322", FirstName = "Stephanie", LastName = "Holsinger" },
            new Employee { Id = 8, OrganisationNumber = "09740322", FirstName = "Rene", LastName = "Hughey" },
            new Employee { Id = 9, OrganisationNumber = "09740322", FirstName = "Robert", LastName = "Rogers" },
            new Employee { Id = 10, OrganisationNumber = "09740322", FirstName = "Richard", LastName = "LaPine" },
            new Employee { Id = 11, OrganisationNumber = "09740322", FirstName = "Kathy", LastName = "Summerfield" },
            new Employee { Id = 12, OrganisationNumber = "09740322", FirstName = "Kathy", LastName = "Bodwin" },
            new Employee { Id = 13, OrganisationNumber = "00002065", FirstName = "Mitch", LastName = "Krause" },
            new Employee { Id = 14, OrganisationNumber = "00002065", FirstName = "George", LastName = "Dow" },
            new Employee { Id = 15, OrganisationNumber = "00002065", FirstName = "Jack", LastName = "Malone" },
            new Employee { Id = 16, OrganisationNumber = "00002065", FirstName = "Bill", LastName = "Schweiz" },
            new Employee { Id = 17, OrganisationNumber = "00002065", FirstName = "Mark", LastName = "Gunter" },
            new Employee { Id = 18, OrganisationNumber = "00002065", FirstName = "Bob", LastName = "Anderson" },
            new Employee { Id = 19, OrganisationNumber = "00002065", FirstName = "Scott", LastName = "Simpson" },
            new Employee { Id = 20, OrganisationNumber = "00002065", FirstName = "Phil", LastName = "Dingman" },
            new Employee { Id = 21, OrganisationNumber = "00002065", FirstName = "Chad", LastName = "Leiker" },
            new Employee { Id = 22, OrganisationNumber = "00002065", FirstName = "Ian", LastName = "Benson" },
            new Employee { Id = 23, OrganisationNumber = "00002065", FirstName = "Nicole", LastName = "Lane" },
            new Employee { Id = 24, OrganisationNumber = "00002065", FirstName = "Steve", LastName = "Lundeen" },
            new Employee { Id = 25, OrganisationNumber = "00002065", FirstName = "Erica", LastName = "Black" },
            new Employee { Id = 26, OrganisationNumber = "00002065", FirstName = "Xenos", LastName = "Mathis" },
            new Employee { Id = 27, OrganisationNumber = "00002065", FirstName = "Kyle", LastName = "Good" },
            new Employee { Id = 28, OrganisationNumber = "00002065", FirstName = "Raja", LastName = "Dejesus" },
            new Employee { Id = 29, OrganisationNumber = "00002065", FirstName = "Timothy", LastName = "Frazier" },
            new Employee { Id = 30, OrganisationNumber = "00002065", FirstName = "Francine", LastName = "Morrison" },
            new Employee { Id = 31, OrganisationNumber = "SC095237", FirstName = "Avram", LastName = "Pate" },
            new Employee { Id = 32, OrganisationNumber = "SC095237", FirstName = "Hammett", LastName = "Coffey" },
            new Employee { Id = 33, OrganisationNumber = "SC095237", FirstName = "Hasad", LastName = "Wise" },
            new Employee { Id = 34, OrganisationNumber = "SC095237", FirstName = "Cullen", LastName = "Riddle" },
            new Employee { Id = 35, OrganisationNumber = "SC095237", FirstName = "Kato", LastName = "Delgado" },
            new Employee { Id = 36, OrganisationNumber = "SC095237", FirstName = "Todd", LastName = "Wright" },
            new Employee { Id = 37, OrganisationNumber = "SC095237", FirstName = "Troy", LastName = "Mccoy" },
            new Employee { Id = 38, OrganisationNumber = "SC095237", FirstName = "Gil", LastName = "Duncan" },
            new Employee { Id = 39, OrganisationNumber = "SC095237", FirstName = "Lionel", LastName = "Espinoza" },
            new Employee { Id = 40, OrganisationNumber = "SC095237", FirstName = "Victor", LastName = "Merrill" },
            new Employee { Id = 41, OrganisationNumber = "SC001111", FirstName = "Gennifer", LastName = "Vance" },
            new Employee { Id = 42, OrganisationNumber = "SC001111", FirstName = "Chancellor", LastName = "Warner" },
            new Employee { Id = 43, OrganisationNumber = "SC001111", FirstName = "Davis", LastName = "Wolf" },
            new Employee { Id = 44, OrganisationNumber = "00966425", FirstName = "Carlos", LastName = "Clarke" },
            new Employee { Id = 45, OrganisationNumber = "00966425", FirstName = "Dolan", LastName = "Mercado" },
            new Employee { Id = 46, OrganisationNumber = "00966425", FirstName = "Helen", LastName = "Guthrie" },
            new Employee { Id = 47, OrganisationNumber = "00966425", FirstName = "Elmo", LastName = "Douglas" },
            new Employee { Id = 48, OrganisationNumber = "00966425", FirstName = "Kane", LastName = "Rice" },
            new Employee { Id = 49, OrganisationNumber = "00966425", FirstName = "Colt", LastName = "Rowland" },
            new Employee { Id = 50, OrganisationNumber = "00966425", FirstName = "John", LastName = "Rose" },
            new Employee { Id = 51, OrganisationNumber = "00966425", FirstName = "Alfonso", LastName = "Hopkins" },
            new Employee { Id = 52, OrganisationNumber = "00966425", FirstName = "Ida", LastName = "Watts" },
            new Employee { Id = 53, OrganisationNumber = "00966425", FirstName = "Jennifer", LastName = "Coleman" },
            new Employee { Id = 54, OrganisationNumber = "00966425", FirstName = "Ciaran", LastName = "Newton" },
            new Employee { Id = 55, OrganisationNumber = "00966425", FirstName = "Hiram", LastName = "Carrillo" },
            new Employee { Id = 56, OrganisationNumber = "00966425", FirstName = "Devin", LastName = "Russell" },
            new Employee { Id = 57, OrganisationNumber = "00966425", FirstName = "Arsenio", LastName = "Jensen" },
            new Employee { Id = 58, OrganisationNumber = "00966425", FirstName = "Otto", LastName = "Gibbs" },
            new Employee { Id = 59, OrganisationNumber = "00966425", FirstName = "Hiram", LastName = "Vega" },
            new Employee { Id = 60, OrganisationNumber = "SC327000", FirstName = "Jarrod", LastName = "Randolph" },
            new Employee { Id = 61, OrganisationNumber = "SC327000", FirstName = "Josiah", LastName = "Gates" },
            new Employee { Id = 62, OrganisationNumber = "SC327000", FirstName = "Brandon", LastName = "Stanley" },
            new Employee { Id = 63, OrganisationNumber = "SC327000", FirstName = "Kennedy", LastName = "Nunez" },
            new Employee { Id = 64, OrganisationNumber = "SC327000", FirstName = "Lewis", LastName = "Sanchez" },
            new Employee { Id = 65, OrganisationNumber = "SC327000", FirstName = "Kassie", LastName = "Chaney" },
            new Employee { Id = 66, OrganisationNumber = "SC327000", FirstName = "Lance", LastName = "Knox" },
            new Employee { Id = 67, OrganisationNumber = "SC327000", FirstName = "Lamar", LastName = "Harrison" },
            new Employee { Id = 68, OrganisationNumber = "SC327000", FirstName = "Honorato", LastName = "Montgomery" },
            new Employee { Id = 69, OrganisationNumber = "00014259", FirstName = "Lisa", LastName = "Nielsen" },
            new Employee { Id = 70, OrganisationNumber = "00014259", FirstName = "Layla", LastName = "Barr" },
            new Employee { Id = 71, OrganisationNumber = "00014259", FirstName = "Nancy", LastName = "Mcclain" },
            new Employee { Id = 72, OrganisationNumber = "00014259", FirstName = "Kato", LastName = "Delgado" },
            new Employee { Id = 73, OrganisationNumber = "00014259", FirstName = "Todd", LastName = "Wright" },
            new Employee { Id = 74, OrganisationNumber = "00014259", FirstName = "Troy", LastName = "Mccoy" },
            new Employee { Id = 75, OrganisationNumber = "00014259", FirstName = "Gil", LastName = "Duncan" },
            new Employee { Id = 76, OrganisationNumber = "00014259", FirstName = "Lionel", LastName = "Espinoza" },
        };
        
        public static void Initialize(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisation>().HasData(Organisations);
            modelBuilder.Entity<Employee>().HasData(Employees);
        }
    }
}