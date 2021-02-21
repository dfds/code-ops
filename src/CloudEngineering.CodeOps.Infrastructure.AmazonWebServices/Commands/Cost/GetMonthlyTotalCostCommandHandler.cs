using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;
using Amazon.Runtime;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost
{
    public sealed class GetMonthlyTotalCostCommandHandler : AwsCommandHandler<GetMonthlyTotalCostCommand, IEnumerable<CostDto>>
    {
        private readonly IMapper _mapper;

        public GetMonthlyTotalCostCommandHandler(IAwsClientFactory awsClientFactory, IMapper mapper, IAwsProfile fallbackProfile = default) : base(awsClientFactory, fallbackProfile)
        {
            _mapper = mapper;
        }

        public async override Task<IEnumerable<CostDto>> Handle(GetMonthlyTotalCostCommand command, CancellationToken cancellationToken = default)
        {
            var result = new List<CostDto>();
            using var client = await _awsClientFactory.Create<IAmazonCostExplorer>(command.Impersonate ?? _fallbackProfile);

            try
            {
                GetCostAndUsageResponse resp = null;

                do
                {
                    var request = new GetCostAndUsageRequest()
                    {
                        Metrics = new List<string>(new[] { Amazon.CostExplorer.Metric.BLENDED_COST.Value }),
                        TimePeriod = CreateDateIntervalForCurrentMonth(),
                        Granularity = Granularity.MONTHLY,
                        NextPageToken = resp?.NextPageToken
                    };

                    if (!string.IsNullOrEmpty(command.AccountIdentifier))
                    {
                        request.Filter = new Expression
                        {
                            Dimensions = new DimensionValues()
                            {
                                Key = Dimension.LINKED_ACCOUNT,
                                Values = new List<string>() { command.AccountIdentifier }
                            }
                        };
                    }
                    else
                    {
                        request.GroupBy = new List<GroupDefinition>(new[]
                        {
                            new GroupDefinition()
                            {
                                Type = GroupDefinitionType.DIMENSION,
                                Key = Dimension.LINKED_ACCOUNT.Value
                            }
                        });
                    }

                    resp = await client.GetCostAndUsageAsync(request, cancellationToken);

                    result.Add(_mapper.Map<CostDto>(resp));
                }
                while (resp.NextPageToken != null);
            }
            catch (AmazonServiceException e)
            {
                throw new Exception(e.Message, e);
            }

            return result.AsEnumerable();
        }

        private static DateInterval CreateDateIntervalForCurrentMonth()
        {
            var currentDate = DateTime.Now;
            var firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            return new DateInterval
            {
                Start = $"{firstDayOfMonth.Year}-{firstDayOfMonth.Month:#00}-{firstDayOfMonth.Day:#00}",
                End = $"{lastDayOfMonth.Year}-{lastDayOfMonth.Month:#00}-{lastDayOfMonth.Day:#00}"
            };
        }
    }
}