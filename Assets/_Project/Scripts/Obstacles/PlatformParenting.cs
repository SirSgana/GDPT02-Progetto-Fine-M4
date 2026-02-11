using UnityEngine;

public class PlatformParenting : MonoBehaviour
{
    //Questo script serve per far si che il player diventi figlio delle piattaforme che si muovono
    //In questo modo il player subirà lo stesso movimento salendo sopra una di esse. 
    //Tuttavia saltando il player perderà questa parentela e quindi risulterà fermo al salto senza avere l'effetto d'inerzia.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
