using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint; //dove va l'oggetto che fa il check del ground. Oggetto avente lo script
    [SerializeField] private float _checkDistance = 0.2f; // grandezza del ray. Quanto distante può essere che dia True
    [SerializeField] private LayerMask _groundMask;       // layer da inserire nell'inspector l'hit layer
    [SerializeField] private float _sphereRadius = 0.2f;  // Raggio sfera

    public bool IsGrounded()
    {
        if (_checkPoint == null) return false;
        else
        {
            return Physics.CheckSphere(transform.position, _checkDistance, _groundMask);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_checkPoint.position, _sphereRadius);
    }
}