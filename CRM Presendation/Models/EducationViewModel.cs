namespace CRM_Presendation.Models
{
    public class EducationViewModel: BaseEntityView
    {
     
        public string? EducationName { get; set; }
        public string? EducationContents { get; set; }
        public string? Comment { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
