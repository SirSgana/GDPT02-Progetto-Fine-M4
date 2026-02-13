using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _xAngle = 0f;
    [SerializeField] private float _yAngle = 0f;
    [SerializeField] private float _zAngle = 0f;

    private int _coinValue = 1;

    private void Update()
    {
        transform.Rotate(_xAngle * Time.deltaTime, _yAngle * Time.deltaTime, _zAngle * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
    
    private void Collect()
    {
        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.AddScore(_coinValue);
        }
        Debug.Log("Moneta Raccolta! Valore: " + _coinValue);
        Destroy(gameObject);
    }
}
