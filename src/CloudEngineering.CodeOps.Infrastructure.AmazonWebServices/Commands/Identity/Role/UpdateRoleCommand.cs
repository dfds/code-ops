using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class UpdateRoleCommand : AwsCommand<Task>
    {
        public string RoleName { get; init; }

        public string Description { get; init; }

        public UpdateRoleCommand(string roleName, string description = default)
        {
            RoleName = roleName;
            Description = description;
        }
    }
}