using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MemoryDontDestroy : MonoBehaviour // AINDA NAO FOI IMPLEMENTADO
{
    public static MemoryDontDestroy memory;

    public KeyCode left1;
    public KeyCode left2;
    public KeyCode up1;
    public KeyCode up2;
    public KeyCode right1;
    public KeyCode right2;
    public KeyCode down1;
    public KeyCode down2;

    void Start()
    {
        memory = this;

        DontDestroyOnLoad(memory);
    } 
}
