using System.ComponentModel.DataAnnotations;

namespace RecALLDemo.Contrib.TextItem.Api.Commands;

public class DeleteTextItemCommand
{
    [Required] public int id { get; set; }
}