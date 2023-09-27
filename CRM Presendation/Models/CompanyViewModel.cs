namespace CRM_Presendation.Models
{
    public class CompanyViewModel: BaseEntityView
    {
        public string? CompanyName { get; set; }
        public string? CompanyLocation { get; set; }
        public int? CompanyPhone { get; set; }
        public string? WebSite { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
