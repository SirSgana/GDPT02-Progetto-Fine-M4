using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeRemaining = 300f; //5min in secondi
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameOverManager _gameOverManager; //attaccando il GameManager trova subito lo script GameOverManager

    private bool _isTimerRunning = false;

    private void Start()
    {
        _isTimerRunning = true;
    }

    private void Update()
    {
        if (_isTimerRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                DisplayTime(_timeRemaining);
            }
            else
            {
                Debug.Log("Tempo Scaduto");
                _timeRemaining = 0;
                _isTimerRunning = false;
                OnTimeOut();
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        //Calcola minuti e secondi
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //Formatta la stringa come 00:00
        _timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    //Prende la funzione del GameOverManager
    private void OnTimeOut()
    { 
        if (_gameOverManager != null)
        {
            _gameOverManager.TriggerGameOver();
        }
    }

    //Funzione richiamata in GroundDamage e TimeCoin per aggiungere/togliere tempo
    public void AddTime(float amount)
    {
        _timeRemaining += amount;
    }
}
