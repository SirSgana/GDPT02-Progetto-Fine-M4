using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GroundCheck groundCheck;
    private Rigidbody _rb;
    private Camera _mainCamera;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotSpeed = 5f;

    [Header("Jump")]
    [SerializeField] private float _jumpForce = 10f;

    private Vector3 _dir;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
    }

    void Update()
    { 
      //Input
      float h = Input.GetAxisRaw("Horizontal"); 
      float v = Input.GetAxisRaw("Vertical");

        //Prendo le direzioni della camera e cambio il mio forward in base a dove guardo
        Vector3 camForward = _mainCamera.transform.forward;
        Vector3 camRight = _mainCamera.transform.right;

        //Qui impedisco al player di partire in aria se guardo in alto e vado avanti (blocco il forward in Y)
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        //Questo calcolo mi serve per cambiare le direzioni in base a dove sto guardando
        _dir = (camForward * v + camRight * h).normalized; 
        
      if (Input.GetKeyDown(KeyCode.Space) && groundCheck.IsGrounded()) 
        {
            Jump(); 
        } 
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _rb.velocity;

        velocity.x = _dir.x * _moveSpeed;
        velocity.z = _dir.z * _moveSpeed;
        _rb.velocity = velocity;

        Rotation(_dir);

    }

    private void Rotation(Vector3 _dir)
    {
        if (_dir != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(_dir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotSpeed * Time.fixedDeltaTime);
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
