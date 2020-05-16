using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    public static SetController controls; // Singleton

    public KeyCode left1;   // KeyCode do botão
    public KeyCode left2;   // KeyCode do botão
    public KeyCode up1;     // KeyCode do botão
    public KeyCode up2;     // KeyCode do botão
    public KeyCode right1;  // KeyCode do botão
    public KeyCode right2;  // KeyCode do botão
    public KeyCode down1;   // KeyCode do botão
    public KeyCode down2;   // KeyCode do botão

    public ButtonController left;  // Referencia do Botão
    public ButtonController right; // Referencia do Botão
    public ButtonController up;    // Referencia do Botão
    public ButtonController down;  // Referencia do Botão

    void Start()
    {
        controls = this; // Singleton

        SetButton(); // Função que altera o KeyCode dos botões para os KeyCodes desse objeto 
    }

    void Update()
    {
        
    }

    public void SetButton() // Função que altera o KeyCode dos botões para os KeyCodes desse objeto
    {
        GameObject LeftArrow = GameObject.Find("Left Button");
        left = LeftArrow.GetComponent<ButtonController>();
        left.setControl(left1, left2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão

        GameObject rightArrow = GameObject.Find("Right Button");
        right = rightArrow.GetComponent<ButtonController>();
        right.setControl(right1, right2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão

        GameObject upArrow = GameObject.Find("Up Button");
        up = upArrow.GetComponent<ButtonController>();
        up.setControl(up1, up2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão 

        GameObject downArrow = GameObject.Find("Down Button");
        down = downArrow.GetComponent<ButtonController>();
        down.setControl(down1, down2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão
    }
}
