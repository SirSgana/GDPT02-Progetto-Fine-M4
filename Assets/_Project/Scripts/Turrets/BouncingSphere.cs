using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingSphere : MonoBehaviour
{

    private Vector3 _bouncingForce = new Vector3(0f, -3f, 0f);
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();    
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_bouncingForce);
    }
}
