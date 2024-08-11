namespace TenantPOC.Services.TenantService.Models
{
    public class CreateTenantRequestModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsIsolaed{ get; set; }
    }
}
