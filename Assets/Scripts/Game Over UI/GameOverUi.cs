using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public static GameOverUi instance;
    private Image panelColor;

    [SerializeField] private float fadeDuration = 1.5f; // cuanto dura el fade


    void Awake()
    {
        //Time.timeScale = 0;
        instance = this;

        panelColor = GetComponent<Image>();

        SetAlpha(0f);
    }

    public void ShowGameOver() {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsed = 0f; // tiempo transcurrido

        while (elapsed < fadeDuration) { 
            elapsed += Time.unscaledDeltaTime; // usa tiempo real, ignora timeScale = 0
            float alpha = Mathf.Lerp(0f, 0.90f, elapsed / fadeDuration); // va de 0 a 0.8
            SetAlpha(alpha);
            yield return null; // espera un frame y continua
        }

    SetAlpha(0.90f); // asegura que termine exacto
}

public void SetAlpha(float targetAlpha)
    {
        if (panelColor != null) { 
            Color tempColor = panelColor.color;
            tempColor.a = targetAlpha;
            panelColor.color = tempColor; 
        }
    }

}
