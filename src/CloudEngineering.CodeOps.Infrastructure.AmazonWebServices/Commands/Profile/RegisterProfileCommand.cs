using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Profile
{
    public sealed class RegisterProfileCommand : AwsCommand<Task>
    {
        [JsonPropertyName("profile")]
        public IAwsProfile Profile { get; init; }

        internal string AccessKey { get; init; }

        internal string SecretKey { get; init; }

        public RegisterProfileCommand(IAwsProfile profile, string accessKey = default, string secretKey = default)
        {
            Profile = profile;
            AccessKey = accessKey;
            SecretKey = secretKey;
        }
    }
}
