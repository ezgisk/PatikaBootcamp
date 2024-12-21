namespace Survivor.Data.Entities
{
    public class Competitor : BaseEntity
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  // Navigation Property
    }
}