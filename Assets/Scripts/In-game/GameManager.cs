using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // garante que só tenha um game manager

    public HitAnimation hitAnimation; // Cria uma referência ao HitAnimation

    public BeatScroller beat;         // Cria uma referencia ao BeatScroller, para pegar o tempo da musica

    public GameObject results;        // Cria uma referência aos resultados


    public AudioSource musica;   // Variável que contem a música
    public bool startPlaying;    // Variável para começar a música

    public int totalNotes;       // total de notas na música
    public int hittedNotes;      // total de notas batidas
    public int greatHits;        // total de notas Great
    public int perfectHits;      // total de notas Perfect
    public int marvelousHits;    // total de notas Marvelous
    public int missedHits;       // total de notas Erradas
    public int goodHits;         // total de notas Good

    public int combo;            // Contador de combo

    public float score;          // Pontuação do jogador

    public float maxPerHit;      // Pontos por Marvelous

    public bool stopMusic;


    void Start()
    {
        instance = this; // garante que só tenha um game manager

        GameObject hitani = GameObject.Find("Animation");
        hitAnimation = hitani.GetComponent<HitAnimation>();


        totalNotes = FindObjectsOfType<NoteObject>().Length; // Acha o total de notas da música
        hittedNotes = 0;
        greatHits = 0;
        perfectHits = 0;
        marvelousHits = 0;
        goodHits = 0;
        missedHits = 0;

        maxPerHit = 1000000 / totalNotes; // Calcula quantos pontos o jogador ganha por Marvelous

    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)                       // Se o jogo ainda não começou
        {
            if (Input.anyKeyDown)                // quando precionar qualquer tecla
            {
                startPlaying = true;             // O jogo começa
                
                beat.hasStarted = true;          // Setas começam a descer

                musica.Play();                   // música começa
            }
        }

        if (startPlaying && !musica.isPlaying && !results.activeInHierarchy) // no final da musica ele ativa o display de resultados
        {
            results.SetActive(true);
        }
    }

    public void NoteHit()                        // Nota foi batida 
    {
        Debug.Log("Hit On Time");                // Manda mensagem no console

        score += 100;                            // Adiciona 100 toda vez que uma nota é batida

        hittedNotes++;                           // Adiciona um acerto

        ComboCount(1);                           // Adiciona 1 no combo
    }

    public void NoteMissed()                     // Nota foi perdida
    {
        Debug.Log("Missed Note");                // Manda mensagem no console

        missedHits++;                            // Adiciona um erro

        ComboCount(0);                           // Zera o combo

        hitAnimation.HitA(-1);                   // Chama a animção de Miss...
    }

    public void ComboCount(int hit)              // Se receber 1 aumenta o Combo, se receber 0 zera o combo
    {
        if (hit == 1)
        {
            combo++;
        }
        else
        {
            combo = 0;
        }
    }

    public void AddHit(int dist)                 // Adiciona pontos baseado no tipo de acerto
    {
        if (dist == 1)                           // Hitou um Marvelous
        {
            Debug.Log("Marvelous");
            marvelousHits++;
            score += maxPerHit;
            hitAnimation.HitA(1);                // Chama a animção de Marvelous!!!
        }
        else if (dist == 2)                      // Hitou um Perfect
        {
            Debug.Log("Perfect");
            perfectHits++;
            score += maxPerHit * 0.625f;
            hitAnimation.HitA(2);                // Chama a animção de Perfect
        }
        else if (dist == 3)                      // Hitou um Great
        {
            Debug.Log("Great");
            greatHits++;
            score += maxPerHit * 0.5f;
            hitAnimation.HitA(3);                // Chama a animção de Great
        }
        else                                     // Hitou um Good
        {
            Debug.Log("Good");
            goodHits++;
            score += maxPerHit * 0.2f;
            hitAnimation.HitA(4);                // Chama a animção de Good
        } 
    }
}
