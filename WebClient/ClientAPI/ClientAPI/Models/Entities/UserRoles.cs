using ClientAPI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ClientAPI.Models.Entities;

public class UserRoles : BaseEntity
{   
    public Guid UserID { get; set; }
    public Guid RoleID { get; set; }
}