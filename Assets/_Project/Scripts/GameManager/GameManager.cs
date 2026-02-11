using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    [SerializeField] private GameObject OptionPanel;

    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowOption()
    {
        OptionPanel.SetActive(!OptionPanel.activeSelf);
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
