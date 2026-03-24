using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientAPI.Models.Base;

public abstract class BaseEntity : BaseDesc
{
    const string DEFAULT_CREATEBY = "SYSTEM";
    const string DEFAULT_UPDATEBY = "SYSTEM";


    #region Identify
    [Key]
    [Column(Order = 1)]
    public Guid Id { get; set; }
    #endregion

    #region Tracking
    [Column(Order = 9995)]
    public bool IsActive { get; set; } = true;
    [Column(Order = 9996)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column(Order = 9997)]
    [MaxLength(50)]
    public string CreatedBy { get; set; } = DEFAULT_CREATEBY;
    [Column(Order = 9998)]
    public DateTime? UpdatedAt { get; set; } = null;

    [Column(Order = 9999)]
    [MaxLength(50)]
    public string? UpdatedBy { get; set; } = null;

    #endregion

}
