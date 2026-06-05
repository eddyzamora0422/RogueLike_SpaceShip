using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtoms : MonoBehaviour
{
    public void OnClick()
    {
        //Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
