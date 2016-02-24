using UnityEngine;

public class FaceTrackMovment : MonoBehaviour {

    [SerializeField] Client receiver = null;
    Transform startPos = null;

    [SerializeField] public float startingX = 0;
    [SerializeField] public float startingY = 0;
    [SerializeField] public float startingZ = 0;

    [SerializeField] public float yawCompensation = 0;
    [SerializeField] public float rollCompensation = 0;

    void Start ()
    {
        startPos = transform;
	}
	
	void Update ()
    {
        startPos.position = new Vector3(startingX + receiver.xPos, startingY, -(receiver.zPos + startingZ));
        startPos.rotation = Quaternion.Euler(receiver.yPos + yawCompensation, receiver.yaw, receiver.roll + rollCompensation);

        new ObjectTracker(startPos.position, startPos.rotation);
    }
}

class ObjectTracker {

    public ObjectTracker(Transform item)
    {
        item.position
    }

}