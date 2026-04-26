namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet
{
    //kopplingstabell för att kunna få en many-2-many koppling
    public class PersonInterest
    {

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int InterestId { get; set; }
        public Interest Interest { get; set; }


    }
}
