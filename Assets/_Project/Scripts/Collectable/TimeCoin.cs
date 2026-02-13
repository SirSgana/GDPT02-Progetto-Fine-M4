using UnityEngine;

public class TimeCoin : MonoBehaviour
{
    [SerializeField] private float _xAngle = 0f;
    [SerializeField] private float _yAngle = 0f;
    [SerializeField] private float _zAngle = 0f;
    [SerializeField] private float _timeBonus = 10f;

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
        //Cerca il TimeManager nella scena
        TimeManager timer = Object.FindFirstObjectByType<TimeManager>();

        //Aggiunge 10 secondi al timer
        if (timer != null) { timer.AddTime(_timeBonus); }

        Destroy(gameObject);
    }
}
