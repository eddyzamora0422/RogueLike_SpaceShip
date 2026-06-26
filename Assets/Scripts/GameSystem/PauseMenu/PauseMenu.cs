using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    private void Awake()
    {
        instance = this;
    }

    public void ContinueButtom()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        GameManager.isPaused = false;
    }

    public void MainMenuButtom()
    {
        print("Deberia ir al menu principal");
    }

    public void ExitButtom()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

    }

}
