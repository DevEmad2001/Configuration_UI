namespace GUI_Adtech.Models
{
    public class AdtechConfig
    {
        public int Seq_Id { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public DateTime ModifiesDate { get; set; }

        // Foreign key for Component
        public int ComponentID { get; set; }
        public AdtechComponent Component { get; set; }
    }

}
