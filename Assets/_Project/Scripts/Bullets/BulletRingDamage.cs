using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRingDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damage);
            }
            Destroy(gameObject);
        }
    }
}
