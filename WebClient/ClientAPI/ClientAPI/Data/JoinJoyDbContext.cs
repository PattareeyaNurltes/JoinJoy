using Microsoft.EntityFrameworkCore;
using ClientAPI.Models.Entities;

public class JoinJoyDbContext : DbContext
{
    public JoinJoyDbContext(DbContextOptions<JoinJoyDbContext> options)
        : base(options) { }

    #region Users / Auth / Policies
    public DbSet<Users> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Permissions> Permissions { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    public DbSet<RolePermissions> RolePermissions { get; set; }
    #endregion
    

}