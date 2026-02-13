using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 6f, -6f);
    [SerializeField] private float _mouseSensitivity = 3f;
    [SerializeField] private float _bottomClamp = -30f;
    [SerializeField] private float _topClamp;

    private float _yaw;
    private float _pitch;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        if (_target == null) return;

        //Input del mouse
        _yaw += Input.GetAxis("Mouse X") * _mouseSensitivity;
        _pitch -= Input.GetAxis("Mouse Y") * _mouseSensitivity;
        _pitch = Mathf.Clamp(_pitch, _bottomClamp, _topClamp);

        //Rotazione su pitch e yaw
        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0);
        
        //Calcolo posizione e rotazione
        Vector3 desiredPosition = _target.position + rotation * _offset;

        Vector3 lookAt = _target.position + Vector3.up * 2;
        Quaternion lookRotation = Quaternion.LookRotation(lookAt - desiredPosition);
        transform.SetPositionAndRotation(desiredPosition, lookRotation);
    }
}
