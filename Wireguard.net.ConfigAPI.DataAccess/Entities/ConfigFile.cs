using System.ComponentModel.DataAnnotations;

namespace Wireguard.net.ConfigAPI.DataAccess.Entities {
    public class ConfigFile {
        public required int Id {get;set;}
        public required Guid UserGuid { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(150)]
        public required string PrivateKey { get; set; }
        [MaxLength(150)]
        public required string PublicKey { get; set; }
        [MaxLength(150)]
        public required string PresharedKey { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public virtual ICollection<PeerEntry>? PeerEntries { get; set; }
        
    }
}