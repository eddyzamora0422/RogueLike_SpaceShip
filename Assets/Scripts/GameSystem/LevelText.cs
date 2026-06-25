using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public TextMeshPro textMesh;

    // Update is called once per frame
    void Update()
    {
        textMesh.text = GameManager.instance.level.ToString();
    }
}
