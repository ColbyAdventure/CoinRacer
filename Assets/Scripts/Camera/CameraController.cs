using UnityEngine;

public class CameraController : MonoBehaviour
{ //Camera Keeps Up With Player, but maintains it's position in the middle lane
    public Transform target;
    private Vector3 offSet;
    void Start()
    {
        offSet = transform.position - target.position;
    }

    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offSet.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);
    }
}
