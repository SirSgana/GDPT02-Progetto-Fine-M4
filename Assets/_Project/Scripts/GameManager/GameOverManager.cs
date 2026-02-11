using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LifeController playerLife;
    [SerializeField] private GameObject gameOverPanel;

    private bool isGameOver = false;

    private void Update()
    {
        if (isGameOver) return;

        if (playerLife != null && playerLife.GetHp() <= 0)
        {
            TriggerGameOver();
        }
    }

    //Public perchè presa anche dal TimeManager
    public void TriggerGameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);

        //Ferma il gioco ed attiva il mouse 
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
