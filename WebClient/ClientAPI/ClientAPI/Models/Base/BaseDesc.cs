using System.ComponentModel.DataAnnotations.Schema;

namespace ClientAPI.Models.Base;

public abstract class BaseDesc
{
    
    [Column(Order = 9992)]
    public string Code { get; set; }

    [Column(Order = 9993)]
    public string Description { get; set; }

    [Column(Order = 9994)]
    public string Remark { get; set; }
  
}
