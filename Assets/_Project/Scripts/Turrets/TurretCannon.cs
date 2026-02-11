using UnityEngine;

public class TurretCannon : MonoBehaviour
{
    [Header("Cannon Aim")]
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _firePoint;

    [Header("Bullet Setup")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate = 2f;
    [SerializeField] private float _bulletSpeed;

    [Header("Attack Range")]
    [SerializeField] private float _range = 20f;
    [SerializeField] private LayerMask _targetLayer;

    private float _nextFireTime;

    void Update()
    {
        if (_target == null) return;

        if (IsTargetVisible())
        {
            HandleAiming();

            if (Time.time >= _nextFireTime)
            {
                Shoot();
                _nextFireTime = Time.time + 1 / _fireRate;
            }
        }
    }

    private Vector3 HandleAiming()
    {
        Vector3 direction = _target.position - transform.position;
        direction.y = 0; //per ignorare l'altezza del player

        if (direction.sqrMagnitude > 0.1f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            //inclinazione massima a 30°
            transform.rotation = lookRotation * Quaternion.Euler(30, 0, 0);
        }
        return direction;
    }

    private bool IsTargetVisible()
    {
        float distance = Vector3.Distance(transform.position, _target.position);
        return distance <= _range;
    }

    private void Shoot()
    {
        //Calcolo velocità necessaria per colpire il target con inclinazione massima a 30°
        Vector3 startPosition = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 targetPosition = new Vector3(_target.position.x, 0, _target.position.z);
        float distance = Vector3.Distance(startPosition, targetPosition);

        float angle = 30f;
        float _radMultiplier = 2.7f;
        float angleInRadians = angle * Mathf.Deg2Rad;
        float gravity = Physics.gravity.magnitude;

        //formula presa da youtube per la gittata che sarebbe: v = sqrt((g * d) / sin(2* theta))
        float v0 = Mathf.Sqrt((gravity * distance) / Mathf.Sin(_radMultiplier * angleInRadians));


        //Sparo del Bullet
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = _firePoint.up * v0;
        Destroy(bullet, 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(_firePoint.position, _range);
    }
}
