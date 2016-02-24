using UnityEngine;
using System.Text;

public class Host : MonoBehaviour {
    
    private UDPHost host;

    [SerializeField] private string ip;
    [SerializeField] private int port;
        
    void Start () {
        host = new UDPHost(ip, port);
	}

    public void SendTest()
    {
        byte[] message = Encoding.ASCII.GetBytes("This is a test");
        host.Send(message);
    }

    void OnDisable()
    {
        host.Close();
    }

    void OnApplicationQuit()
    {
        host.Close();
    }
}
