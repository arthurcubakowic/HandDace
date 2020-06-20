using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;        // Variável que marca quando a seta está no tempo certo para ser batida

    public KeyCode buttonKey;        // Tecla escolhida para o botão
    public KeyCode buttonKey2;       // Segunda tecla escolhida para o botão

    public string thisTag;           // tag da seta


    void Start()
    {

        thisTag = this.tag;                                 // adiciona a tag da seta em um script para o codigo saber qual tipo de seta é

        SetControl();                                       // Sincroniza os botões da seta com os dos Buttons
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonKey) || Input.GetKeyDown(buttonKey2)) // Se o botão 1 ou botão 2 estiver precionado
        {
            if (canBePressed)                                            // Se estiver no tempo certo
            {
                gameObject.SetActive(false);                             // Se a seta foi batida, entao o objeto some

                GameManager.instance.NoteHit();                          // A seta foi batida

                if (transform.position.y < 0.6 && transform.position.y > 0.4)
                {
                    GameManager.instance.AddHit(1);                      // Chama um acerto Marvelous
                } 
                else if (transform.position.y < 0.7 && transform.position.y > 0.3)
                {
                    GameManager.instance.AddHit(2);                      // Chama um acerto Perfect
                }
                else if (transform.position.y < 0.8 && transform.position.y > 0.2)
                {
                    GameManager.instance.AddHit(3);                      // Chama um acerto Great
                }
                else
                {
                    GameManager.instance.AddHit(4);                      // Chama um acerto Good (pseudo erro)
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)                      // Ativação do OnTrigger, Instante em que um Collider entra no range do outro
    {
        if(other.CompareTag("Botão"))                                    // Tag dos botões
        {
            canBePressed = true;                                         // A seta está no tempo certo

        }
    }
    private void OnTriggerExit2D(Collider2D other)                       // Desativação do OnTrigger, Instante em que um Collider sai do range do outro
    {
        if(other.CompareTag("Botão"))                                    // Tag dos botões
        {
            if (gameObject.activeInHierarchy)                            // Se o objeto ainda não foi batido 
            {
                canBePressed = false;                                    // A seta não pode mais ser precionada

                GameManager.instance.NoteMissed();                       // A seta foi perdida
            }
        }
    }

    public void SetControl()  // Todas as setas recebem o mesmo botão dos Buttons ao inicio da cena
    {
        switch (thisTag)
        {
            case "Left":
                buttonKey = MemoryDontDestroy.memory.left1;
                buttonKey2 = MemoryDontDestroy.memory.left2;
                break;
            case "Right":
                buttonKey = MemoryDontDestroy.memory.right1;
                buttonKey2 = MemoryDontDestroy.memory.right2;
                break;
            case "Up":
                buttonKey = MemoryDontDestroy.memory.up1;
                buttonKey2 = MemoryDontDestroy.memory.up2;
                break;
            case "Down":
                buttonKey = MemoryDontDestroy.memory.down1;
                buttonKey2 = MemoryDontDestroy.memory.down2;
                break;
        }
    }
}
