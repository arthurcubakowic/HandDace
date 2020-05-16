using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Fader : MonoBehaviour
{
    Image image;
    public string Scene;
    public float duration;

    void Start()
    {
        duration = 0.25f;
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 1);
        image.enabled = true;

        image.DOFade(0, duration)
            .OnComplete(() => { image.enabled = false; });
    }

    public void FadeToGame()
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        image.DOFade(1, duration)
            .OnComplete(() => { SceneManager.LoadScene(Scene); });
    }
}


// retirado da aula do Flapy Bird
