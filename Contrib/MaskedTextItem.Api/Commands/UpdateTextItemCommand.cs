using System.ComponentModel.DataAnnotations;

namespace RecALLDemo.Contrib.MaskedTextItem.Api.Commands;



public class UpdateTextItemCommand {
    [Required] public int Id { get; set; }
    
    [Required] public string Content { get; set; }
    
    
    [Required] public string MaskedContent { get; set; }
    
}