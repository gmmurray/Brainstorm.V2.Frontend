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
    public new List<CreateIdeaField> Fields { get; set; } = new List<CreateIdeaField>();
  }

  public class CreateIdeaField : IdeaField
  {
    public bool ValueBool { get; set; }
  }

  public class UpdateIdeaModel : Idea
  {
    [Required(ErrorMessage = "name is required")]
    new public string? Name { get; set; }
    [ValidateComplexType]
    public new List<UpdateIdeaField> Fields { get; set; } = new List<UpdateIdeaField>();
  }

  public class UpdateIdeaField : IdeaField
  {
    public bool ValueBool { get; set; }
  }
}