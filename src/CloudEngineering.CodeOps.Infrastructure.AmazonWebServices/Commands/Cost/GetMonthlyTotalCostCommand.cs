using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost
{
    public sealed class GetMonthlyTotalCostCommand : AwsCommand<Task<IEnumerable<AwsCostDto>>>
    {
        [JsonPropertyName("accountIdentifier")]
        public string AccountIdentifier { get; init; }

        public GetMonthlyTotalCostCommand(string accountIdentifier = default)
        {
            AccountIdentifier = accountIdentifier;
        }
    }
}