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

        left1 = MemoryDontDestroy.memory.left1;
        left2 = MemoryDontDestroy.memory.left2;
        up1 = MemoryDontDestroy.memory.up1;
        up2 = MemoryDontDestroy.memory.up2;
        right1 = MemoryDontDestroy.memory.right1;
        right2 = MemoryDontDestroy.memory.right2;
        down1 = MemoryDontDestroy.memory.down1;
        down2 = MemoryDontDestroy.memory.down2;

        SetButton(); // Função que altera o KeyCode dos botões para os KeyCodes desse objeto 
    }

    public void SetButton() // Função que altera o KeyCode dos botões para os KeyCodes desse objeto
    {
        GameObject LeftArrow = GameObject.Find("Left Button");
        left = LeftArrow.GetComponent<ButtonController>();
        left.SetControl(left1, left2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão

        GameObject rightArrow = GameObject.Find("Right Button");
        right = rightArrow.GetComponent<ButtonController>();
        right.SetControl(right1, right2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão

        GameObject upArrow = GameObject.Find("Up Button");
        up = upArrow.GetComponent<ButtonController>();
        up.SetControl(up1, up2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão 

        GameObject downArrow = GameObject.Find("Down Button");
        down = downArrow.GetComponent<ButtonController>();
        down.SetControl(down1, down2); // Chama a função do GameObject ButtonController que troca o KeyCode do botão
    }
}
