using UnityEngine;
using System;

public class Client : MonoBehaviour {

    private UDPClient client;

    [SerializeField] private int port;

    // FaceAPI
    private float _xPos = 0;
    public float xPos
    {
        get { return _xPos; }
        set { _xPos = value; }
    }

    private float _yPos = 0;
    public float yPos
    {
        get { return _yPos; }
        set { _yPos = value; }
    }

    private float _zPos = 0;
    public float zPos
    {
        get { return _zPos; }
        set { _zPos = value; }
    }

    private float _pitch = 0;
    public float pitch
    {
        get { return _pitch; }
        set { _pitch = value; }
    }

    private float _yaw = 0;
    public float yaw
    {
        get { return _yaw; }
        set { _yaw = value; }
    }

    private float _roll = 0;
    public float roll
    {
        get { return _roll; }
        set { _roll = value; }
    }

    void Start () {
        client = new UDPClient(port, OnReceive, OnError);
	}

    void OnReceive(byte[] data)
    {
        for (int i = 0; i < 6; i++)
        {
            double datum = BitConverter.ToDouble(data, i * 8);
            var j = i + 1;
            switch (j)
            {
                case 1:
                    {
                        xPos = (float)datum;
                        break;
                    }
                case 2:
                    {
                        pitch = (float)datum;
                        break;
                    }
                case 3:
                    {
                        zPos = (float)datum;
                        break;
                    }
                case 4:
                    {
                        yaw = (float)datum;
                        break;
                    }
                case 5:
                    {
                        yPos = (float)datum;
                        break;
                    }
                case 6:
                    {
                        roll = (float)datum;
                        break;
                    }
            }
        }
    }

    void OnError(System.Exception ex)
    {
        print(ex.StackTrace);
    }

    void OnDisable()
    {
        client.Close();
    }

    void OnApplicationQuit()
    {
        client.Close();
    }
}
