using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour
{
    public Text texto;

    void Update()
    {
        texto.text = GameManager.instance.combo.ToString();
    }
}
