using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{

    public void PlayButtom()
    {
        SceneManager.LoadScene("MainGame");
      
    }

    public void ExitButtom()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }


}
