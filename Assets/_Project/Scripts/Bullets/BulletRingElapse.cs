using UnityEngine;

public class BulletRingElapse : MonoBehaviour
{
    [SerializeField] private float _startSize = 3f;
    [SerializeField] private float _endSize = 10f;
    [SerializeField] private float _duration = 5f;

    private float elapseTime = 0f;
    private Vector3 initialScale;
    private Vector3 finalScale;

    void Start()
    {
        //Imposto lo scale di partenza ed arrivo
        initialScale = new Vector3(_startSize, transform.localScale.y, _startSize);
        finalScale = new Vector3(_endSize,transform.localScale.y, _endSize);

        //Applico la scala iniziale
        transform.localScale = initialScale;
    }

    void Update()
    {
        if (elapseTime < _duration)
        {
            elapseTime += Time.deltaTime;

            //Calcolo fattore di interpolazione
            float t = elapseTime / _duration;

            //Applico l'espansione (cambio scale) 
            transform.localScale = Vector3.Lerp(initialScale, finalScale, t);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
