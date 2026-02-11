using UnityEngine;

public class TurretAOE : MonoBehaviour
{

    //Perdonatemi ma qui volevo ricreare una torretta perpetua quindi non ho fatto nessun tipo di detection.

    [SerializeField] private GameObject _bulletRingPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        SpawnRing(transform.position);
    }

    void SpawnRing(Vector3 position)
    {
        //Istanzia il bulletRing
        Instantiate(_bulletRingPrefab, transform.position, Quaternion.identity);
    }
}













//[Header("Bullet Setup")]
//[SerializeField] private GameObject _bulletPrefab;
//[SerializeField] private Transform _firePoint;
//[SerializeField] private float _bulletSpeed;
//[SerializeField] private float _range;

//[SerializeField] private float _maxRadius = 10f;
//[SerializeField] private float _duration = 5f;


//public LayerMask playerLayer;
//private float _timer = 0f;
//private bool isExpanding = false;

//void Update()
//{
//    //Gestione espansione con raggio attivo
//    if (isExpanding)
//    {
//        _timer += Time.deltaTime;

//        //Calcolo ingrandimento
//        float dimension = _timer / _duration;

//        if (dimension <= 1.0f)
//        {
//            //Calcolo raggio attuale
//            float currentRadius = Mathf.Lerp(0, _maxRadius, dimension);
//            CheckForPlayer(currentRadius);
//        }
//        else { isExpanding = false; }
//    }
//    Shoot();
//}
//private void OnCollisionEnter(Collision collision)
//{
//    _timer = 0f;
//    isExpanding = true;
//}

//private void CheckForPlayer(float radius)
//{
//    //Uso un Array dove c'è un solo player per poi filtrare con l'OverlapSphere per il layermask del player
//    Collider[] hitPlayers = Physics.OverlapSphere(transform.position, radius, playerLayer);

//    if (hitPlayers.Length > 0)
//    {
//        Debug.Log("Il raggio ha raggiunto il Player");
//    }
//}

//private void Shoot()
//{
//    //Raycast per individuare il bersaglio
//    RaycastHit hit;
//    if (Physics.Raycast(transform.position, transform.forward, out hit, _range))
//    {
//        Debug.Log("Colpito:" + hit.collider.name);

//        //Gestione danno con interfaccia IDamageable
//        IDamageable damageable = hit.collider.GetComponent<IDamageable>();
//        if (damageable != null)
//        {
//            damageable.Damage(10); //Danno inflitto
//        }
//    }
//    //Sparo del Bullet
//    GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
//    bullet.GetComponent<Rigidbody>().velocity = _firePoint.forward * _bulletSpeed;
//    Destroy(bullet, 5f);
//}
//}
