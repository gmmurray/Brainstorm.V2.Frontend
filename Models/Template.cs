namespace Brainstorm.V2.Frontend.Models
{
  public class Template
  {
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public IEnumerable<TemplateField> Fields { get; set; } = Enumerable.Empty<TemplateField>();
  }

  public class TemplateField
  {
    public string? Name { get; set; }
    public TemplateFieldType Type { get; set; }
  }

  public enum TemplateFieldType
  {
    text,
    number,
    boolean,
  }

  public class TemplateFilter
  {
    public int? Limit { get; set; }
    public IEnumerable<string> Ids { get; set; } = Enumerable.Empty<string>();
  }
}