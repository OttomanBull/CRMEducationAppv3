namespace CRM_Presendation.Models
{
    public class RequestViewModel:BaseEntityView
    {
        public int? PersonId { get; set; }
        public int? ActivityId { get; set; }
        public bool? DemandStatus { get; set; }
        public int? NumberOfPeople { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
