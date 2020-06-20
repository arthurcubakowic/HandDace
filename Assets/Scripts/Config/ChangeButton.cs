using System.Collections;
using UnityEngine;
using System;

public class ChangeButton : MonoBehaviour
{
    Event keyEvent;
    KeyCode newKey;

    bool waitingForKey;

    void Start()
    {
        waitingForKey = false;
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment (String keyName)
    {
        if (!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey();

        switch (keyName)
        {
            case "left1":
                MemoryDontDestroy.memory.left1 = newKey;
                PlayerPrefs.SetString("left1Key", MemoryDontDestroy.memory.left1.ToString());
                break;
            case "left2":
                MemoryDontDestroy.memory.left2 = newKey;
                PlayerPrefs.SetString("left2Key", MemoryDontDestroy.memory.left2.ToString());
                break;
            case "up1":
                MemoryDontDestroy.memory.up1 = newKey;
                PlayerPrefs.SetString("up1Key", MemoryDontDestroy.memory.up1.ToString());
                break;
            case "up2":
                MemoryDontDestroy.memory.up2 = newKey;
                PlayerPrefs.SetString("up2Key", MemoryDontDestroy.memory.up2.ToString());
                break;
            case "right1":
                MemoryDontDestroy.memory.right1 = newKey;
                PlayerPrefs.SetString("right1Key", MemoryDontDestroy.memory.right1.ToString());
                break;
            case "right2":
                MemoryDontDestroy.memory.right2 = newKey;
                PlayerPrefs.SetString("right2Key", MemoryDontDestroy.memory.right2.ToString());
                break;
            case "down1":
                MemoryDontDestroy.memory.down1 = newKey;
                PlayerPrefs.SetString("down1Key", MemoryDontDestroy.memory.down1.ToString());
                break;
            case "down2":
                MemoryDontDestroy.memory.down2 = newKey;
                PlayerPrefs.SetString("down2Key", MemoryDontDestroy.memory.down2.ToString());
                break;

        }

        yield return null;
    }
}


// Codigo baseado em um tutorial do canal Studica News
// https://www.youtube.com/watch?v=iSxifRKQKAA