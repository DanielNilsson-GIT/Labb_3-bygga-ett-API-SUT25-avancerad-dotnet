namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet
{
    public class Person
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }

        //varje person ska ha många intressen och många hemsidor
        public ICollection<PersonInterest> PersonInterests { get; set; }
        public ICollection<Website> Websites { get; set; }





    }
}
