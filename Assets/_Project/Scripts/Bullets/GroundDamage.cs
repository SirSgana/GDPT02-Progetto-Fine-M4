using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDamage : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float timeSubtract = -10f;

    private void OnCollisionEnter(Collision collision)
    {
        //Cerca il TimeManager nella scena
        TimeManager timer = Object.FindObjectOfType<TimeManager>();

        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damage);
            }
            //Toglie tempo se tocchi il ground
            if (timer != null) { timer.AddTime(timeSubtract); }

            //Respawn all'ultimo checkpoint
            PlayerRespawn respawn = collision.gameObject.GetComponent<PlayerRespawn>();
            if (respawn != null) { respawn.Respawn(); }
        }
    }
}
