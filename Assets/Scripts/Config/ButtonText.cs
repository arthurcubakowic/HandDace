using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{

    public MemoryDontDestroy settings; // Referência de variável global

    public Text texto1; // up 1
    public Text texto2; // up 2
    public Text texto3; // Right 1
    public Text texto4; // Right 2
    public Text texto5; // Left 1
    public Text texto6; // Left 2
    public Text texto7; // Down 1
    public Text texto8; // Down 2

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject controles = GameObject.Find("Settings");
        settings = controles.GetComponent<MemoryDontDestroy>();  // Referencia o GameObject com os Bottões configurados 

        GameObject text1 = GameObject.Find("Up Button 1"); // Referencia o GameObject do texto
        texto1 = text1.GetComponent<Text>();

        GameObject text2 = GameObject.Find("Up Button 2"); // Referencia o GameObject do texto
        texto2 = text2.GetComponent<Text>();

        GameObject text3 = GameObject.Find("Right Button 1"); // Referencia o GameObject do texto
        texto3 = text3.GetComponent<Text>();

        GameObject text4 = GameObject.Find("Right Button 2"); // Referencia o GameObject do texto
        texto4 = text4.GetComponent<Text>();

        GameObject text5 = GameObject.Find("Left Button 1"); // Referencia o GameObject do texto
        texto5 = text5.GetComponent<Text>();

        GameObject text6 = GameObject.Find("Left Button 2"); // Referencia o GameObject do texto
        texto6 = text6.GetComponent<Text>();

        GameObject text7 = GameObject.Find("Down Button 1"); // Referencia o GameObject do texto
        texto7 = text7.GetComponent<Text>();

        GameObject text8 = GameObject.Find("Down Button 2"); // Referencia o GameObject do texto
        texto8 = text8.GetComponent<Text>();

        texto1.text = settings.up1.ToString(); // Altera o texto da caixa de texto para o novo valor que consta na variável global
        texto2.text = settings.up2.ToString();
        texto3.text = settings.right1.ToString();
        texto4.text = settings.right2.ToString();
        texto5.text = settings.left1.ToString();
        texto6.text = settings.left2.ToString();
        texto7.text = settings.down1.ToString();
        texto8.text = settings.down2.ToString();
    }
}
