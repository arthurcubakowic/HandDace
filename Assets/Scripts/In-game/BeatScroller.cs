using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float speed; // Velocidade do jogo

    public float BPM; // Batidas por minuto da musica

    public bool hasStarted; // Se o jogo ja começou

    void Start()
    {
        speed = 1f;
    }

    void Update()
    {
        
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, BPM * 2 / 30 * Time.deltaTime * speed, 0f); // Setas caem apenas no vetor Y a medida que a música passa
        }

    }
}
