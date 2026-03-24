using ClientAPI.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientAPI.Models.Entities;

public class Users : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    public Guid? RegionKey { get; set; }

    [MaxLength(3)]
    public string? CountryCode { get; set; }

    [MaxLength(100)]
    public string? Firstname { get; set; }

    [MaxLength(100)]
    public string? Lastname { get; set; }

    [MaxLength(250)]
    public string? FullName { get; set; }
    public string? Profile_Url { get; set; }

    [NotMapped]
    public string[] Roles { get; set; }

}
