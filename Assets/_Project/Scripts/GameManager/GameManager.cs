using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    [SerializeField] private GameObject _OptionPanel;

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowOption()
    {
        _OptionPanel.SetActive(!_OptionPanel.activeSelf);
    }

    public void OnExit()
    {
        Debug.Log("Esci dal gioco");
        Application.Quit();
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
