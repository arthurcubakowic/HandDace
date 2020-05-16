using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer buttonState; // Cria uma Sprite 2D do botão

    public Sprite defaultButton; // Sprite do botão sem ser precionado
    public Sprite pressedButton; // Sprite do botão depoiis de ser precionado

    public KeyCode buttonKey;  // Tecla escolhida para o botão
    public KeyCode buttonKey2;  // Segunda tecla escolhida para o botão

    // Start is called before the first frame update
    void Start()
    {
        buttonState = GetComponent<SpriteRenderer>(); // Trás o Sprite a partir do Game Object  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonKey) || Input.GetKeyDown(buttonKey2)) // Se o botão 1 ou botão 2 estiver precionado
        {
            buttonState.sprite = pressedButton; // A sprite do botão vira a pressedButton
        }

        if (Input.GetKeyUp(buttonKey) || Input.GetKeyUp(buttonKey2)) // Se o botão 1 ou botão 2 não estiverem precionados
                                                                     // Se você mantiver um botão precionado e apertar o botão, o jogo cairá no estado de não precionado 
        {
            buttonState.sprite = defaultButton; // A sprite do botão vira a defaultButton
        }
    }

    public void setControl(KeyCode A, KeyCode B) // troca os KeyCodes dos botões
    {
        buttonKey = A;
        buttonKey2 = B;
    }
}
// Lembrando que esse código lê apenas eventos de precionar e soltar teclas, um botão que se mantem precionado nessa lógica é um botão que ainda não foi solto e nao um precionado propriamente dito
