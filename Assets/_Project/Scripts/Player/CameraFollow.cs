using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0f, 6f, -6f);
    [SerializeField] private float followSpeed = 5f;

    Vector3 newPosition;

    private void LateUpdate()
    {
        Vector3 position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, followSpeed * Time.deltaTime);

        transform.LookAt(target);
    }
}
