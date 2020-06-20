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

    public GameObject combosObject;     // Cria uma referência ao GameObject combos

    public Fader transition; // referencia o Fader de transição
    public GameObject transitionObj; // referencia o GameObject de transição


    public AudioSource musica;   // Variável que contem a música
    public bool startPlaying;    // Variável para começar a música

    public int totalNotes;       // total de notas na música
    public int hittedNotes;      // total de notas batidas
    public int greatHits;        // total de notas Great
    public int perfectHits;      // total de notas Perfect
    public int marvelousHits;    // total de notas Marvelous
    public int missedHits;       // total de notas Erradas
    public int goodHits;         // total de notas Good
    public int maxCombo;         // Combo Maximo da sua performance

    public int combo;            // Contador de combo

    public float score;          // Pontuação do jogador

    public float maxPerHit;      // Pontos por Marvelous

    public bool stopMusic;


    private void Awake() // Basicamente tudo que está aqui é para me ajudar a programar, não influencia diretamente na Gameplay, mas evita possiveis erros 
    {
        combosObject.SetActive(false); // Deixa a tela de combo desativada
        results.SetActive(false);      // Deixa a tela de resultados desativada
        transitionObj.SetActive(true); // Deixa o Fader ativado

        if (!MemoryDontDestroy.memory) // Se o jogo não for iniciado corretamente e não abrir o settings de controle, ele volta ao menu inicial
        {
            SceneManager.LoadScene("Menu");
        }

    }

    void Start()
    {
        instance = this; // garante que só tenha um game manager

        transition.GetComponent<Fader>();

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

        if (results.activeInHierarchy)  // Assim que o Display de resultados aparecer na tela, quando qualquer tecla for apertada o jogo volta para o começo
        {
            if (Input.anyKeyDown)
            {
                transition.FadeToGame();
            }
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

            if (combo > maxCombo) maxCombo = combo; // Faz com que a variavel maxCombo receba o maior combo que o jogador fez na partida

            if (combo > 3)
            {
                combosObject.SetActive(true); // Se o combo do jogador for maior que 3, a tela de combo fica visivel 
            }
        }
        else
        {
            combo = 0;
            combosObject.SetActive(false); // Se o combo do jogador for menor que 3, a tela de combo fica desativada 
        }

    }

    public void AddHit(int dist)                 // Adiciona pontos baseado no tipo de acerto
    {
        GameObject toDestroy = GameObject.FindGameObjectWithTag("HitNote");
        if (toDestroy != null) toDestroy.SetActive(false);
            
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
