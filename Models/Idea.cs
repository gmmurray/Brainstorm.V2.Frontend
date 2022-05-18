namespace Brainstorm.V2.Frontend.Models
{
  public class Idea
  {
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public Template? Template { get; set; }
    public string? TemplateId { get; set; }
    public IEnumerable<IdeaField> Fields { get; set; } = Enumerable.Empty<IdeaField>();
  }

  public class IdeaField : TemplateField
  {
    public string? Value { get; set; }
  }

  public class IdeaFilter
  {
    public int? Limit { get; set; }
    public string? TemplateId { get; set; }
  }
}