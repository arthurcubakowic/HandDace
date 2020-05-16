using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChangeButton : MonoBehaviour // AINDA NAO FOI IMPLEMENTADO
{
    private Button button { get { return GetComponent<Button>(); } }



    public MemoryDontDestroy settings;

    public KeyCode left1;
    public KeyCode left2;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() => changeAll());

    }

    void changeAll()
    {
        left1 = KeyCode.LeftArrow;
        left2 = KeyCode.B;

        Input.GetKeyDown(left2);

        GameObject controles = GameObject.Find("Settings");
        settings = controles.GetComponent<MemoryDontDestroy>();  // Referencia o GameObject com os Bottões configurados 

        Debug.Log("Opa negão");

        settings.left1 = left1;
        settings.left2 = left2;
    }
    public void PressedButton()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
            {
                left1 = kcode;
            }


        }
    }

}

