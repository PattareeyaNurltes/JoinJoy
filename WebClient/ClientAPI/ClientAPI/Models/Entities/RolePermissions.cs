using ClientAPI.Models.Base;

namespace ClientAPI.Models.Entities;

public class RolePermissions : BaseEntity
{
    public Guid RoleID { get; set; }
    public Guid PermissionID { get; set; }
}