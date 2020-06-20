using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetResults : MonoBehaviour
{
    public static SetResults results;   // referencia seu próprio GameObject

    public Text marvelous;      // referencia Todas as caixas de texto do display de resultados
    public Text perfect;
    public Text great;
    public Text good;
    public Text miss;
    public Text totalNotes;
    public Text maxCombo;
    public Text score;


    void Start()
    {
        results = this; // garante que só tenha uma tela de resultados

        marvelous.text = GameManager.instance.marvelousHits.ToString(); // Escreve na caixa de texto a quantidades de notas batidas que foi contada no Game Manager
        perfect.text = GameManager.instance.perfectHits.ToString();
        great.text = GameManager.instance.greatHits.ToString();
        good.text = GameManager.instance.goodHits.ToString();
        miss.text = GameManager.instance.missedHits.ToString();
        totalNotes.text = GameManager.instance.totalNotes.ToString();
        maxCombo.text = GameManager.instance.maxCombo.ToString();
        score.text = GameManager.instance.score.ToString();
    }
}
