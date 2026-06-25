using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{

    public void PlayButtom()
    {
        SceneManager.LoadScene("MainGame");
        GameManager.instance.gameTimer = 0;
        GameManager.isVictory = false;
    }

    public void ExitButtom()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
