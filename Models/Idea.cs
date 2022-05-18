using System.ComponentModel.DataAnnotations;

namespace Brainstorm.V2.Frontend.Models
{
  public class Idea
  {
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public Template? Template { get; set; }
    public string? TemplateId { get; set; }
    public List<IdeaField> Fields { get; set; } = new();
  }

  public class IdeaField : TemplateField
  {
    [Required(ErrorMessage = "value is required")]
    public string? Value { get; set; }
  }

  public class IdeaFilter
  {
    public int? Limit { get; set; }
    public string? TemplateId { get; set; }
  }

  public class CreateIdeaModel : Idea
  {
    [Required(ErrorMessage = "name is required")]
    new public string? Name { get; set; }
    [Required(ErrorMessage = "template is required")]
    new public string? TemplateId { get; set; }
    [ValidateComplexType]
    new public List<IdeaField> Fields { get; set; } = new List<IdeaField>();
  }
}