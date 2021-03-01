using System;
using System.Collections.Generic;
using System.Linq;
using Amazon.CostExplorer.Model;
using AutoMapper;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.DataTransferObjects.Cost;

namespace CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Mapping.Converters
{
    public class GetCostAndUsageResponseToCostDto : ITypeConverter<GetCostAndUsageResponse, CostDto>
    {
        public CostDto Convert(GetCostAndUsageResponse source, CostDto destination, ResolutionContext context)
        {
            destination ??= new CostDto();

            destination.DimensionValueAttributes = source.DimensionValueAttributes?.Select(o => new DimensionValueAttributeDto
            {
                Attributes = o.Attributes,
                Value = o.Value
            });
            
            destination.ResultsByTime = source.ResultsByTime?.Select(o => new ResultByTimeDto
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
            });

            return destination;
        }
    }
}