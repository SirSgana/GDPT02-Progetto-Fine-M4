using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0f, 6f, -6f);
    [SerializeField] float mouseSensitivity = 3f;
    [SerializeField] float bottomClamp = -30f;
    [SerializeField] float topClamp;

    private float yaw;
    private float pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        //Input del mouse
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, bottomClamp, topClamp);

        //Rotazione su pitch e yaw
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        
        //Calcolo posizione e rotazione
        Vector3 desiredPosition = target.position + rotation * offset;

        Vector3 lookAt = target.position + Vector3.up * 2;
        Quaternion lookRotation = Quaternion.LookRotation(lookAt - desiredPosition);
        transform.SetPositionAndRotation(desiredPosition, lookRotation);
    }
}
