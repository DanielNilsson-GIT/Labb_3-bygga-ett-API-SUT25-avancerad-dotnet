namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        


        public ICollection<Website>? Websites { get; set; }
        public ICollection<PersonInterest> personInterests { get; set; }
    }
}
