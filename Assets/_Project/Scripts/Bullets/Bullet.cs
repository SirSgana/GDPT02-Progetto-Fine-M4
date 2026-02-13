using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(_damage);
            }
            Destroy(gameObject);
        }
    }
}
