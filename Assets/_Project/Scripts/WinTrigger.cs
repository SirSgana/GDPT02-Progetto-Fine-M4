using UnityEngine;
using TMPro;
public class WinTrigger : MonoBehaviour
{

    [SerializeField] private int coinsRequired = 25;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI infoText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currentCoins = CoinManager.Instance.GetTotalCoins();

            if (currentCoins >= coinsRequired)
            {
                winPanel.SetActive(true);
                infoPanel.SetActive(false);
                Time.timeScale = 0f;

                //Sblocca il cursore ed il mouse
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                int missingCoins = coinsRequired - currentCoins;
                infoText.text = $"Hai raccolto {currentCoins} su {coinsRequired}";
                infoPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        infoPanel.SetActive(false);
    }
}
