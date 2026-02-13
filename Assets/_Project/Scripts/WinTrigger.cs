using UnityEngine;
using TMPro;
public class WinTrigger : MonoBehaviour
{

    [SerializeField] private int _coinsRequired = 25;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private TextMeshProUGUI _infoText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int currentCoins = CoinManager.Instance.GetTotalCoins();

            if (currentCoins >= _coinsRequired)
            {
                _winPanel.SetActive(true);
                _infoPanel.SetActive(false);
                Time.timeScale = 0f;

                //Sblocca il cursore ed il mouse
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                int missingCoins = _coinsRequired - currentCoins;
                _infoText.text = $"Hai raccolto {currentCoins} su {_coinsRequired}";
                _infoPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _infoPanel.SetActive(false);
    }
}
