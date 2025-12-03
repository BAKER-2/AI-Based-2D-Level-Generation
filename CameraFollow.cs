using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;          // assign your Player here
    public float smoothing = 5f;      // camera follow speed

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos,
                                          smoothing * Time.deltaTime);
    }
}
