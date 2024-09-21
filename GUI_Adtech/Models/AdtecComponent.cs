namespace GUI_Adtech.Models
{
    public class AdtechComponent
    {
        public int ComponentID { get; set; }
        public string ComponentName { get; set; }

        // Foreign key for System
        public int SystemID { get; set; }
        public AdtechSystem System { get; set; }

        // Each component can have multiple parameters in the Config table
        public ICollection<AdtechConfig> Configs { get; set; }
    }

}
