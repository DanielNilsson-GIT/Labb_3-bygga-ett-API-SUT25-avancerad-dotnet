namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.DTO
{
    public record WebsiteDTO
    {
        public record WebsitesByPerson()
        {
            public int PersonId { get; init; }
            public string PersonName { get; init; }
            public List<string> Websites { get; init; }

        }

        public record AddNewWebsiteRequest() 
        {
            public int PersonId { get; init; }
            public int InterestId { get; init; }
            public string WebsiteURL{ get; init; }
        }

        public record WebsiteResponseDTO
        {
            public int Id { get; init; }
            public string WebsiteURL { get; init; }
            public int PersonId { get; init; }
            public int InterestId { get; init; }
        }

    }
}
