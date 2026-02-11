using UnityEngine;

public class TurretGatling: MonoBehaviour
{
    [Header("Turret Setup")]
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _range = 20f;

    [Header("Bullet Setup")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _bulletSpeed;

    private float _nextFireTime;

    private void Update()
    {
        if (_target == null) return; //nullo se il player non esiste

        ////Gestisce la funzione di emersione della torretta per ora bypassata perchè faccio altro
        //Emerge();

        //Calcolo direzione bersaglio
        Vector3 direction = _target.position - transform.position;

        //Controllo distanza e linea di vista con il Physics Query
        if (direction.magnitude <= _range)
        {
            transform.LookAt(_target); //Rotazione torretta verso il player

            //Aggiungiamo un tempo di ricarica del proiettile
            if (Time.time >= _nextFireTime)
            {
                Shoot();
                _nextFireTime = Time.time + 1 / _fireRate;
            }
        }
    }

    private void Shoot()
    {
        //Raycast per individuare il bersaglio
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _range))
        {
            Debug.Log("Colpito:" + hit.collider.name);
        }

        //Sparo del Bullet
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = _firePoint.forward * _bulletSpeed;
        Destroy(bullet, 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_firePoint.position, _range);
    }
}

//IDEA far emergere la torretta tipo effetto sorpresa qui sotto prototipo fallito vado avanti per ora.

//[Header("Emerge Setup")]
//[SerializeField] private float _turretEmergeRange = 5f;
//[SerializeField] private float _targetY = 3f;
//[SerializeField] private float _emergeSpeed = 5f;
//private void Emerge()
//{
//    RaycastHit hit;
//    //Per vedere il raggio della sfera
//    Debug.DrawRay(transform.position, Vector3.up * _turretEmergeRange, Color.yellow);

//    //
//    if (Physics.Raycast(transform.position, transform.up, out hit, _turretEmergeRange))
//    {
//        if (hit.collider.CompareTag("Player"))
//        {
//            //Muove tutta la torretta
//            Vector3 currentParentPos = transform.parent.position;
//            Vector3 targetPos = new Vector3(currentParentPos.x, _targetY, currentParentPos.z);
//            transform.parent.position = Vector3.MoveTowards(currentParentPos, targetPos, _emergeSpeed * Time.deltaTime);
//        }

//    }
//}