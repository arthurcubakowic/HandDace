using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetResults : MonoBehaviour
{
    public GameManager instance; // referencia o Game Manager

    public GameObject results;   // referencia seu próprio GameObjct

    public Text marvelous;      // referencia Todas as caixas de texto do display de resultados
    public Text perfect;
    public Text great;
    public Text good;
    public Text miss;
    public Text totalNotes;
    public Text score;


    void Start()
    {
        instance.GetComponent<GameManager>(); // Pega os componentes de todas as caixas de texto do display de resultados
        marvelous.GetComponent<Text>();
        perfect.GetComponent<Text>();
        great.GetComponent<Text>();
        good.GetComponent<Text>();
        miss.GetComponent<Text>();
        totalNotes.GetComponent<Text>();
        score.GetComponent<Text>();

        marvelous.text = instance.marvelousHits.ToString(); // Escreve na caixa de texto a quantidades de notas batidas que foi contada no Game Manager
        perfect.text = instance.perfectHits.ToString();
        great.text = instance.greatHits.ToString();
        good.text = instance.goodHits.ToString();
        miss.text = instance.missedHits.ToString();
        totalNotes.text = instance.totalNotes.ToString();
        score.text = instance.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (results.activeInHierarchy)  // Assim que o Display de resultados aparecer na tela, quando qualquer tecla for apertada o jogo volta para o começo
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
