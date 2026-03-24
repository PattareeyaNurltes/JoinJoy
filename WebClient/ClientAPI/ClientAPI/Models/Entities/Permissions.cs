using ClientAPI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Models.Entities;

public class Permissions : BaseEntity
{
    [MaxLength(50)]
    public string PermissionName { get; set; }
}
