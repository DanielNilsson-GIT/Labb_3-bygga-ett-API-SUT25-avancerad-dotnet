namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet
{
    public class Website
    {

        public int Id { get; set; }
        public string WebSiteURL { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }



    }
}
