using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class UnregisterProfileCommand : AwsCommand<Task>
    {
        [JsonPropertyName("profileName")]
        public string ProfileName { get; init; }

        public UnregisterProfileCommand(string profileName)
        {
            ProfileName = profileName;
        }
    }
}
