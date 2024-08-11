using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenantPOC.Models
{
    public class Tenant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string? ConnectionString { get; set; }
        public string SubscribtionLevel { get; set; }
    }
}
