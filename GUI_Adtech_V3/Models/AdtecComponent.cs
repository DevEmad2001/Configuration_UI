using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GUI_Adtech.Models
{
    public class AdtechComponent
    {
        [Key]  // تحديد الـ Primary Key
        public int ComponentID { get; set; }

        [Required(ErrorMessage = "Component Name is required")]  // تحقق من أن اسم المكون مطلوب
        [StringLength(100, ErrorMessage = "Component Name cannot be longer than 100 characters")]
        public string ComponentName { get; set; }

        //[Required]  // المفتاح الأجنبي يجب أن يكون موجود
        //public int SystemID { get; set; }

        //[Required]  // التأكد من أن الـ System مربوط بشكل صحيح
        //public AdtechSystem System { get; set; }

        //public ICollection<AdtechConfig> Configs { get; set; }
    }
}
