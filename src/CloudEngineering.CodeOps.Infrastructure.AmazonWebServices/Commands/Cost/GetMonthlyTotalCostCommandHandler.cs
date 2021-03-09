using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;
using Amazon.Runtime;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.Cost
{
    public sealed class GetMonthlyTotalCostCommandHandler : AwsCommandHandler<GetMonthlyTotalCostCommand, IEnumerable<CostDto>>
    {
        public GetMonthlyTotalCostCommandHandler(IAwsClientFactory awsClientFactory) : base(awsClientFactory)
        {
        }

        public async override Task<IEnumerable<CostDto>> Handle(GetMonthlyTotalCostCommand command, CancellationToken cancellationToken = default)
        {
            var result = new List<CostDto>();
            using var client = _awsClientFactory.Create<AmazonCostExplorerClient>(command.AssumeProfile);

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

                    var dto = new CostDto
                    {
                        DimensionValueAttributes = resp.DimensionValueAttributes?.Select(o => new DimensionValueAttributeDto
                        {
                            Attributes = o.Attributes,
                            Value = o.Value
                        }),

                        ResultsByTime = resp.ResultsByTime?.Select(o => new ResultByTimeDto
                        {
                            Total = o.Total?.Select(kvp => new KeyValuePair<string, MetricValueDto>(kvp.Key, new MetricValueDto
                            {
                                Amount = kvp.Value.Amount,
                                Unit = kvp.Value.Unit
                            })),
                            StartDate = DateTime.Parse(o.TimePeriod.Start),
                            EndDate = DateTime.Parse(o.TimePeriod.End),
                            Estimated = o.Estimated,
                            Groups = o.Groups?.Select(g => new GroupDto
                            {
                                Keys = g.Keys?.AsEnumerable(),
                                Metrics = g.Metrics?.Select(m => new KeyValuePair<string, MetricValueDto>(m.Key, new MetricValueDto
                                {
                                    Amount = m.Value.Amount,
                                    Unit = m.Value.Unit
                                }))
                            })
                        })
                    };

                    result.Add(dto);
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