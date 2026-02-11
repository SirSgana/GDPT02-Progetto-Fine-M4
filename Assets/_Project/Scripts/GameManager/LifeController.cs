using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int minHp = 0;
    [SerializeField] private Slider healthSlider;

    private int currentHp;

    private void Awake()
    {
        currentHp = maxHp;
        healthSlider.maxValue = maxHp;
        healthSlider.value = currentHp;
    }
    public int GetHp() => currentHp;

    private void SetHp(int hp)
    {
        currentHp = Mathf.Clamp(hp, minHp, maxHp);
        healthSlider.value = currentHp;
    }

    public void Damage(int damage)
    {
        SetHp(currentHp - damage);
        //CheckHp();
        Debug.Log("Il player ha ancora: " + currentHp + " Vita rimasta");
    }


    //Questo non serve più dal momento che ho fatto il Pannello GameOver
    //Se il Player viene distrutto non è possibile leggere gli hp a 0
    //private void CheckHp()
    //{
    //    if (currentHp <= minHp)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
