using System.ComponentModel.DataAnnotations;

namespace GUI_Adtech_V2.Models.Sys
{
    public class AdtechSystem
    {
        [Key]  // تحديد Primary Key
        public int SystemID { get; set; }

        [Required(ErrorMessage = "System Name is required")]
        [StringLength(100, ErrorMessage = "System Name cannot be longer than 100 characters")]
        public string SystemName { get; set; }

        //public ICollection<AdtechComponent> Components { get; set; }

    }
}
