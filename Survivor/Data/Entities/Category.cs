using Survivor.Data.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<Competitor> Competitors { get; set; }  // One-to-many relationship
}
