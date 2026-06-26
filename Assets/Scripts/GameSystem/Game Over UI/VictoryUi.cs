using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class VictoryUi : MonoBehaviour
{
    public static VictoryUi instance;

    private Image panelColor;
    [SerializeField] private float fadeDuration = 1.5f; // cuanto dura el fade


    private void Start()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsed = 0f; // tiempo transcurrido

        while (elapsed < fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime; // usa tiempo real, ignora timeScale = 0
            float alpha = Mathf.Lerp(0f, 0.90f, elapsed / fadeDuration); // va de 0 a 0.8
            SetAlpha(alpha);
            yield return null; // espera un frame y continua
        }

        SetAlpha(0.90f); // asegura que termine exacto
    }

    public void SetAlpha(float targetAlpha)
    {
        if (panelColor != null)
        {
            Color tempColor = panelColor.color;
            tempColor.a = targetAlpha;
            panelColor.color = tempColor;
        }
    }

    public void MainMenuButtom()
    {
        SceneManager.LoadScene("MainMenu");
        GameManager.isPaused = false;
        GameManager.isVictory = false;
        GameManager.instance.gameTimer = 0;
        EnemySpawner.bossTime = false;
    }
}
