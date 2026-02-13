using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float _xAngle = 0f;
    [SerializeField] private float _yAngle = 0f;
    [SerializeField] private float _zAngle = 0f;


    private void Update()
    {
        transform.Rotate(_xAngle * Time.deltaTime, _yAngle * Time.deltaTime, _zAngle * Time.deltaTime);
    }
}
