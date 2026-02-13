using UnityEngine;

public class BulletRingElapse : MonoBehaviour
{
    [SerializeField] private float _startSize = 3f;
    [SerializeField] private float _endSize = 10f;
    [SerializeField] private float _duration = 5f;

    private float _elapseTime = 0f;
    private Vector3 _initialScale;
    private Vector3 _finalScale;

    void Start()
    {
        //Imposto lo scale di partenza ed arrivo
        _initialScale = new Vector3(_startSize, transform.localScale.y, _startSize);
        _finalScale = new Vector3(_endSize,transform.localScale.y, _endSize);

        //Applico la scala iniziale
        transform.localScale = _initialScale;
    }

    void Update()
    {
        if (_elapseTime < _duration)
        {
            _elapseTime += Time.deltaTime;

            //Calcolo fattore di interpolazione
            float t = _elapseTime / _duration;

            //Applico l'espansione (cambio scale) 
            transform.localScale = Vector3.Lerp(_initialScale, _finalScale, t);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
