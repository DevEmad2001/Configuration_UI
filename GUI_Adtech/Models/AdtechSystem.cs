using System.ComponentModel;

namespace GUI_Adtech.Models
{
    public class AdtechSystem
    {
        public int SystemID { get; set; }
        public string SystemName { get; set; }

        // Navigation property: a system can have many components
        public ICollection<Component> Components { get; set; }
    }

}
