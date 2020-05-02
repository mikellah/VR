
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float smoothSpeed = 10f;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
         Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed*Time.deltaTime);

        transform.position = smoothPosition;
        transform.LookAt(target);
    }
}
