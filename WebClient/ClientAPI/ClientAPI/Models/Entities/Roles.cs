using ClientAPI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Models.Entities;

public class Roles : BaseEntity
{
    [MaxLength(50)]
    public string RoleName { get; set; }
}
