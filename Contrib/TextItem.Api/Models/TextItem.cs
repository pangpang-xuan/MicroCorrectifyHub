namespace RecALLDemo.Contrib.TextItem.Api.Models;

public class TextItem
{

    public int Id { get; set; }

    public int? ItemId { get; set; } //题号

    public string Content { get; set; }

    public string UserIdentityGuid { get; set; }  //区分用户

    public bool IsDeleted { get; set; }  //软删除


}
