using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    public static HitAnimation hitAnimation; // singleton

    public GameObject marvelous; // referencia os prefabs de animação
    public GameObject perfect;
    public GameObject great;
    public GameObject good;
    public GameObject miss;

    void Start()
    {
        hitAnimation = this; // singleton
    }

    void Update()
    {


    }

    public void HitA(int num) // instancia um objeto para cada tipo de acerto
    {
        if (num == 1)
        {
            Instantiate(marvelous, transform.position, marvelous.transform.rotation);
        }
        else if (num == 2)
        {
            Instantiate(perfect, transform.position, perfect.transform.rotation);
        }
        else if (num == 3)
        {
            Instantiate(great, transform.position, great.transform.rotation);
        }
        else if (num == 4)
        {
            Instantiate(good, transform.position, good.transform.rotation);
        }
        else
        {
            Instantiate(miss, transform.position, miss.transform.rotation);
        } 

    }
}
