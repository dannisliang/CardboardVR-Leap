using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDPHost {
    
    private Socket s;
    private IPAddress broadcast;
    private int port;
    private IPEndPoint endpoint;
    private Thread hostThread;
    
    public UDPHost(string ip, int port)
    {
        this.port = port;
        broadcast = IPAddress.Parse(ip);

        hostThread = new Thread(
            new ThreadStart(StartServer));
        hostThread.IsBackground = true;
        hostThread.Start();
    }

    void StartServer() {
        endpoint = new IPEndPoint(broadcast, port);
        s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    }

    public void Send(byte[] buff)
    {
        s.SendTo(buff, endpoint);
    }

    public void Close()
    {
        if (hostThread != null)
            hostThread.Abort();
        s.Close();
    }
}
