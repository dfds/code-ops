using System.Text.Json.Serialization;

namespace CloudEngineering.CodeOps.Infrastructure.Azure.GraphClient.DataTransferObjects
{
   public class AzureAppRoleAssignment
   {
       [JsonPropertyName("principalId")]
       public string PrincipalId { get; set; }

       [JsonPropertyName("resourceId")]
       public string ResourceId { get; set; }

       [JsonPropertyName("appRoleId")]
       public string AppRoleId { get; set; }
   }
}
