using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 300f; //5min in secondi
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameOverManager gameOverManager; //attaccando il GameManager trova subito lo script GameOverManager

    private bool isTimerRunning = false;

    private void Start()
    {
        isTimerRunning = true;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Tempo Scaduto");
                timeRemaining = 0;
                isTimerRunning = false;
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
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    //Prende la funzione del GameOverManager
    private void OnTimeOut()
    { 
        if (gameOverManager != null)
        {
            gameOverManager.TriggerGameOver();
        }
    }

    //Funzione richiamata in GroundDamage e TimeCoin per aggiungere/togliere tempo
    public void AddTime(float amount)
    {
        timeRemaining += amount;
    }
}
