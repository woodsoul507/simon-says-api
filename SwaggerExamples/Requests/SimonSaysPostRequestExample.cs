using SimonSays.API.Core;
using Swashbuckle.AspNetCore.Filters;

namespace SimonSays.API.SwaggerExamples.Requests
{
    public class SimonSaysPostRequestExample : IExamplesProvider<SayModel>
    {
        public SayModel GetExamples()
        {
            return new SayModel
            {
                Id = "811f2c97-1bdb-4be2-b610-1920a112e2e0-258333523301",
                Says = { 2, 4, 5 }
            };
        }
    }
}