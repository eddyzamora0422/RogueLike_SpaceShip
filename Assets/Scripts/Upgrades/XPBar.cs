using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        slider.value = GameManager.instance.xp / GameManager.instance.xpToNextLevel;
    }
}
