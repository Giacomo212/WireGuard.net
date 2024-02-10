using System.ComponentModel.DataAnnotations;

namespace Wireguard.net.ConfigAPI.DataAccess.Entities {
    public class PeerEntry {
        
        public required int Id {get;set;}
        public required int ConfigFileId { get; set; }
        [MaxLength(50)]
        public required string IPAddress { get; set; }
        [MaxLength(150)]
        public required string PresharedKey { get; set; }
        [MaxLength(150)]
        public required string PublicKey { get; set; }
    }
}