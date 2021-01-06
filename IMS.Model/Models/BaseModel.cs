using System;

namespace IMS.Model.Models
{
    public class BaseModel
    {
        // This common model used for audit trail.
        public int CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModifiedId { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
