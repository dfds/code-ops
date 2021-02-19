using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Identity.Role
{
    public sealed class DeleteRoleCommand : AwsCommand<Task>
    {
        public string RoleName { get; init; }

        public DeleteRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
    }
}