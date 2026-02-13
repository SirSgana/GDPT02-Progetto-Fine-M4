using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 6f, -6f);
    [SerializeField] private float _followSpeed = 5f;

    private Vector3 _newPosition;

    private void LateUpdate()
    {
        Vector3 position = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, position, _followSpeed * Time.deltaTime);

        transform.LookAt(_target);
    }
}
