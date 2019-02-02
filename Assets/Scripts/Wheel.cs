using System.Collections;
using UnityEngine;

public class box : MonoBehaviour
{

    public WheelCollider targetbox;
    private Vector3 boxPosition = new Vector3();
    private Quaternion boxRotation = new Quaternion();

    private void Update()
    {
        targetbox.GetWorldPose(out boxPosition, out boxRotation);
        transform.position = boxPosition;
        transform.rotation = boxRotation;
    }
}
