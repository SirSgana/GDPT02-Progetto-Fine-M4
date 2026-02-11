using UnityEngine;

public class TimeCoin : MonoBehaviour
{
    [SerializeField] private float xAngle = 0f;
    [SerializeField] private float yAngle = 0f;
    [SerializeField] private float zAngle = 0f;
    [SerializeField] private float timeBonus = 10f;

    private void Update()
    {
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime);
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
        if (timer != null) { timer.AddTime(timeBonus); }

        Destroy(gameObject);
    }
}
