using System;
using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.DataTransferObjects
{
   public class AzureAppRoleAssignmentDto
   {
       [JsonPropertyName("id")]
       public string Id { get; set; }

       [JsonPropertyName("creationTimeStamp")]
       public DateTime CreationTimeStamp{ get; set; }

       [JsonPropertyName("principalType")]
       public string PrincipalType { get; set; }

       [JsonPropertyName("principalId")]
       public string PrincipalId { get; set; }

       [JsonPropertyName("principalDisplayName")]
       public string PrincipalDisplayName { get; set; }

       [JsonPropertyName("resourceId")]
       public string ResourceId { get; set; }

       [JsonPropertyName("resourceDisplayName")]
       public string ResourceDisplayName { get; set; }
   }
}
