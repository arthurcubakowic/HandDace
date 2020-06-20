using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MemoryDontDestroy : MonoBehaviour
{
    public static MemoryDontDestroy memory;

    public KeyCode left1 { get; set; }
    public KeyCode left2 { get; set; }
    public KeyCode up1 { get; set; }
    public KeyCode up2 { get; set; }
    public KeyCode right1 { get; set; }
    public KeyCode right2 { get; set; }
    public KeyCode down1 { get; set; }
    public KeyCode down2 { get; set; }

    private void Awake()
    {
        if (memory == null)
        {
            DontDestroyOnLoad(gameObject);
            memory = this;
        }
        else if (memory != this)
        {
            Destroy(gameObject);
        }

        left1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("left1Key", "LeftArrow"));
        left2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("left2Key", "A"));
        up1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("up1Key", "UpArrow"));
        up2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("up2Key", "W"));
        right1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("right1Key", "RightArrow"));
        right2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("right2Key", "D"));
        down1 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("down1Key", "DownArrow"));
        down2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("down2Key", "S"));

    }

    void Start()
    {

    } 
}


// Codigo baseado em um tutorial do canal Studica News
// https://www.youtube.com/watch?v=iSxifRKQKAA
