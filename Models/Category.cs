public class Category
{
  public Category(string name)
  {
    Name = name;
    Id = Guid.NewGuid();
  }
  public Guid Id { get; set; } = Guid.NewGuid();
  public string Name { get; set; }
  public string Icon { get; set; }
  public Guid? ParentCategoryId { get; set; }
  public virtual Category ParentCategory { get; set; }
  public Guid UserId { get; set; }
}