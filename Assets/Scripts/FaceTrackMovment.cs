using UnityEngine;

public class FaceTrackMovment : MonoBehaviour {

    [SerializeField] UDPReceive receiver = null;
    Transform startPos = null;

    [SerializeField] public float yawCompensation = 0;
    
    void Start ()
    {
        startPos = transform;
	}
	
	void Update ()
    {
        startPos.position = new Vector3(receiver.xPos, 0, -receiver.zPos);
        startPos.rotation = Quaternion.Euler((receiver.yPos + yawCompensation), receiver.yaw, receiver.roll);
    }
}