using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public Text txtTime;
    public bool isGameOver { get; private set; } = false;
    
    float timerDebut;

    public GameObject txtGameOver;
    public Button btnPause;
    public Button btnReprendrePartie;
    public Button btnQuitterPartie;
    public Button btnQuitterMenu;
    public GameObject menuPause;
    public Text txtPointDeVie;
    public bool isPaused = false;

    int nbVie = 5;
    public static bool uiIsOpen;

    void Start()
    {
        instance = this;
        // temps du timer départ
        timerDebut = 0;
        // quand qu'on clique sur le bouton pause et le jeu se met en pause
        btnPause.onClick.AddListener(PauseTime);
        // quand qu'on clique sur le jeu se remet en marche
        btnReprendrePartie.onClick.AddListener(ResumePartie);
        btnQuitterMenu.onClick.AddListener(btnQuitterMenu_Clicked);
        btnPause.onClick.AddListener(btnPause_Clicked);
        btnQuitterPartie.onClick.AddListener(btnQuitterPartie_Clicked);

    }

    void Update()
    {

        // debuter le timer
        timerDebut = timerDebut + Time.deltaTime;
        TimeSpan timer = TimeSpan.FromSeconds(timerDebut);
        // calculer le temps en minutes:secondes
        txtTime.text = timer.ToString(@"mm\:ss\:ff");
        Debug.Log(timer.ToString(@"mm\:ss\:ff"));
        txtPointDeVie.text = nbVie.ToString();
        if (Input.GetKeyDown(KeyCode.P))
        {
            // ouvrir le menuPause
            menuPause.SetActive(true);
            isPaused = !isPaused;
            PauseTime();
        }
    }
    void PauseTime()
    {
        // vérifier si le temps est en pause ou non
        Time.timeScale = 0f;
        isPaused = true;

    }

    void ResumePartie()
    {
        // reprend la partie si le temps n'est plus en pause
        Time.timeScale = 1f;
        isPaused = false;
        // fait disparaite le menuPause
        menuPause.SetActive(false);

    }

    public void PointDeViePerdu()
    {
        // point de vie
        nbVie -= 1;

        // si le nombre de point est égale 0 la partie est terminer
        if (nbVie == 0)
        {
            GameOver();
        }

    }
    // Fin de la partie
    public void GameOver()
    {
        isGameOver = true;
        txtGameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    void btnPause_Clicked()
    {
        // ouvrir le menuPause
        menuPause.SetActive(true);
        //Affiche message dans la console quand il est cliqué
        Debug.Log("Bouton pause a été cliqué");
    }
    void btnQuitterMenu_Clicked()
    {
        // fermer le menuPause
        menuPause.SetActive(false);
        //Affiche message dans la console quand il est cliqué
        Debug.Log("Bouton quitter menu à été cliqué");
    }
    void btnQuitterPartie_Clicked()
    {
        //charge la scene MenuAccueil
        SceneManager.LoadScene("Menu Accueil");
        //Affiche message dans la console quand il est cliqué
        Debug.Log("Bouton quitter  partie à été cliqué");
    }
}
