namespace Wireguard.net.ConfigAPI.Logic;

public interface IServerConfigProvider {    

    public string ServerPrivateKey { get; set; }
    public string ServerPublicKey { get; set; }
    public string ServerAddress { get; set; }
    public int ServerPort { get; set; }
}