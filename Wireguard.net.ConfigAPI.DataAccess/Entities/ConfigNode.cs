using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Wireguard.net.ConfigAPI.DataAccess;

[PrimaryKey(nameof(Key))]
public class ConfigNodeEntity {
    [MaxLength(50)]
    public required string Key { get; set; }
    [MaxLength(200)]
    public required string Value { get; set; }
}