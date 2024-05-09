using System.ComponentModel.DataAnnotations;

namespace RecALLDemo.Contrib.MaskedTextItem.Api.Commands;



public class DeleteTextItemCommand
{
    [Required] public int id { get; set; }
}