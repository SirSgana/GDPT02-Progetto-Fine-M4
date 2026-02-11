using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int totalCoins = 0;

    public static CoinManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddScore(int value)
    {
        totalCoins += value;
        scoreText.text = totalCoins.ToString();
    }

    //Variabile per consentire allo script WinTrigger di leggere le monete totali
    public int GetTotalCoins() 
    { 
        return totalCoins; 
    } 
}
