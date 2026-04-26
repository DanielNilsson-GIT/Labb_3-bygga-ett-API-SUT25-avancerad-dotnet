namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.DTO
{
    public record PersonDTO
    {
        public record CreatePersonRequest()
        {
            public string Name { get; init; }
            public int Phone { get; init; }
           
        }
    }
}
