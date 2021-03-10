using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost
{
    public sealed class GetMonthlyTotalCostCommand : AwsCommand<IEnumerable<CostDto>>
    {
        [JsonPropertyName("accountIdentifier")]
        public string AccountIdentifier { get; init; }

        public GetMonthlyTotalCostCommand(string accountIdentifier = default)
        {
            // this is a test comment in master branch
            AccountIdentifier = accountIdentifier;
        }
    }
}