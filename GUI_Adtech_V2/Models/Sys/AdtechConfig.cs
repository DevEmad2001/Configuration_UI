using System.ComponentModel.DataAnnotations;

namespace GUI_Adtech_V2.Models.Sys
{
    public class AdtechConfig
    {
        [Key]  // المفتاح الأساسي للـ Config
        public int Seq_Id { get; set; }

        [Required(ErrorMessage = "Parameter Name is required")]
        [StringLength(50, ErrorMessage = "Parameter Name cannot be longer than 50 characters")]
        public string ParameterName { get; set; }

        [Required(ErrorMessage = "Parameter Value is required")]
        public string ParameterValue { get; set; }

        [Required]  // التحقق من أن التاريخ مطلوب
        public DateTime ModifiesDate { get; set; }

        // العمود الجديد لاسم المكون
        [Required(ErrorMessage = "Component Name is required")]
        [StringLength(100)]
        public string ComponentName { get; set; }
        //[Required]  // المفتاح الأجنبي لـ Component
        //    public int ComponentID { get; set; }

        //    [Required]
        //    public AdtechComponent Component { get; set; }
        //}ٍس
    }
}
