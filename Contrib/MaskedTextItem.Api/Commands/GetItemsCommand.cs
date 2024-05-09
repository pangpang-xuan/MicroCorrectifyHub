using System.ComponentModel.DataAnnotations;

namespace RecALLDemo.Contrib.MaskedTextItem.Api.Commands;




public class GetItemsCommand{
    
    [Required] public IEnumerable<int> Ids { get; set; }
    //给一堆id
}