using Microsoft.Identity.Client;
using System.Dynamic;

namespace Labb_3_bygga_ett_API_SUT25_avancerad_dotnet.DTO
{
    public record InterestDTO
    {
        public record CreateInterestByPersonRequest()
        {
            public int PersonId { get; init; }
            public string PersonName { get; init; }
            public List<string> Interests { get; init; }

        }

        public record AddNewIntererstRequest()
        {
            
            public string Title { get; init; }
            public string Descripiton { get; init; }



        }
    }
}
