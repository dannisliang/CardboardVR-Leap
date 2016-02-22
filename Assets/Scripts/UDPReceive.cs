using UnityEngine;

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/*
    Credit where credit is due (based off marcteys implementation):
    https://github.com/marcteys/unityFaceTracking
*/

public class UDPReceive: MonoBehaviour {
	
	Thread receiveThread;
	UdpClient client;
    
	public int port;

    // FaceAPI
    public float xPos = 0;
    public float yPos = 0;
    public float zPos = 0;
    public float pitch = 0;
    public float yaw = 0;
    public float roll = 0;
	

	public void Start() {
        receiveThread = new Thread(
			new ThreadStart(ReceiveData));
		receiveThread.IsBackground = true;
		receiveThread.Start();
	}
	
	// receive thread 
	private void ReceiveData() {
		
		client = new UdpClient(port);
		while (receiveThread != null) {
			try {
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
				byte[] data = client.Receive(ref anyIP);

                for (int i = 0; i < 6; i++)	{
   					double datum = BitConverter.ToDouble(data, i * 8);
					var j = i+1;
					switch (j)
					{
						case 1: {
							xPos = (float)datum;
						    break;
						} case 2: {
							pitch = (float)datum;
						    break;
						} case 3: {
							zPos = (float)datum;
							break;
						} case 4: {
							yaw = (float)datum;
						    break;
						} case 5: {
                            yPos = (float)datum;
                            break;
						} case 6: {
						    roll = (float)datum;
							break;
						}
					}
				}
			} catch (Exception err) {
				print(err.ToString());
			}
		}
	}
    
	void OnDisable() {
		if (receiveThread != null)
			receiveThread.Abort();
		client.Close();
	}

	void OnApplicationQuit() {
		if (receiveThread != null)
			receiveThread.Abort();
		client.Close();
	}
}