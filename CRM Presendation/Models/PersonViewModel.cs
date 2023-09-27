namespace CRM_Presendation.Models
{
    public class PersonViewModel: BaseEntityView
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Status { get; set; }
        public int? Phone { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public string? Comment { get; set; }
    }
}

