using UnityEngine;

public class FaceTrackMovment : MonoBehaviour {

    [SerializeField]
    UDPReceive receiver = null;

    Transform startPos = null;

    [SerializeField]
    float reductionPositionFactor = 1;

    [SerializeField]
    float reductionRotationFactor = 1;


    void Start ()
    {
        startPos = transform;
	}
	
	void Update ()
    {
        transform.position = new Vector3(receiver.xPos, 0, -receiver.zPos);
        transform.rotation = Quaternion.Euler((receiver.yPos - 25), receiver.yaw, receiver.roll);
    }
}
