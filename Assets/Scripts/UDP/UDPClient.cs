using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public delegate void MessageListener(byte[] buff);
public delegate void ErrorListener(Exception ex);

public class UDPClient {

    private int port;
    private Thread receiveThread;
    private UdpClient client;

    private MessageListener mListener;
    private ErrorListener eListener;

    public UDPClient(int port, MessageListener mListener, ErrorListener eListener)
    {
        this.port = port;
        this.mListener = mListener;
        this.eListener = eListener;

        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }
    
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (receiveThread != null)
        {
            try {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);

                // Sends data to the receiver
                mListener(data);
            } catch (Exception err)
            {
                eListener(err);
            }
        }
    }

    public void Close()
    {
        if (receiveThread != null)
            receiveThread.Abort();
        client.Close();
    }
}
