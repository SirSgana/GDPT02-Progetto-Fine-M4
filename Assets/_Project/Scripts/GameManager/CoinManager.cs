using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private int _totalCoins = 0;

    public static CoinManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddScore(int value)
    {
        _totalCoins += value;
        _scoreText.text = _totalCoins.ToString();
    }

    //Variabile per consentire allo script WinTrigger di leggere le monete totali
    public int GetTotalCoins() 
    { 
        return _totalCoins; 
    } 
}
