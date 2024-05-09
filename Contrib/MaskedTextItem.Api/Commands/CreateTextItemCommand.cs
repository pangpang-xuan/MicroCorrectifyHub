using System.ComponentModel.DataAnnotations;

namespace RecALLDemo.Contrib.MaskedTextItem.Api.Commands;



public class CreateTextItemCommand{
    
    //规定客户端->服务端怎么发送数据
    [Required] public string Content { get; set; }
    
    [Required] public string MaskedContent { get; set; }

    
    
}