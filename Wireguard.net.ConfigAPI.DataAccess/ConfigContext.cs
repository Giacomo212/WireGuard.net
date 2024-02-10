using Microsoft.EntityFrameworkCore;
using Wireguard.net.ConfigAPI.DataAccess.Entities;

namespace Wireguard.net.ConfigAPI.DataAccess;
public class ConfigContext : DbContext {
    public ConfigContext(DbContextOptions options) : base(options) {
    }

    protected ConfigContext() {
    }

    public DbSet<PeerEntry> PeerEntries { get; set; }
    public DbSet<ConfigFile> ConfigFiles { get; set; }
    public DbSet<ConfigNodeEntity> ConfigNodes { get; set; }
}