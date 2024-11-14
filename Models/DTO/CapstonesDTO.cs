namespace CapstoneGenerator.Client.Models.DTO
{
    public class CapstonesDTO
    {
        public int CapstoneId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Categories { get; set; } = "";
        public string CreatedBy { get; set; } = "";
        public float Rating { get; set; }

        public ICollection<string> CapstoneTechnology { get; set; }
    }
}
