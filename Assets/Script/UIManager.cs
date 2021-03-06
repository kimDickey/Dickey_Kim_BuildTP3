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
    
    
    float timerDebut;

    
    public Button btnPause;
    public Button btnReprendrePartie;
    public Button btnQuitterPartie;
    public Button btnQuitterMenu;
    public GameObject menuPause;
    
    
    //public Text txtPointDeVie;
    public bool isPaused = false;

    
    public static bool uiIsOpen;

    void Start()
    {
        #if !UNITY_EDITOR && UNITY_WEBGL
        UnityEngine.WebGLInput.captureAllKeyboardInput = false;
        #endif
        instance = this;
        // temps du timer d?part
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
        //txtPointDeVie.text = nbVie.ToString();
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
        // v?rifier si le temps est en pause ou non
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

 
    void btnPause_Clicked()
    {
        // ouvrir le menuPause
        menuPause.SetActive(true);
        //Affiche message dans la console quand il est cliqu?
        Debug.Log("Bouton pause a ?t? cliqu?");
    }
    void btnQuitterMenu_Clicked()
    {
        // fermer le menuPause
        menuPause.SetActive(false);
        //Affiche message dans la console quand il est cliqu?
        Debug.Log("Bouton quitter menu ? ?t? cliqu?");
    }
    void btnQuitterPartie_Clicked()
    {
        //charge la scene MenuAccueil
        SceneManager.LoadScene("Menu Accueil");
        //Affiche message dans la console quand il est cliqu?
        Debug.Log("Bouton quitter  partie ? ?t? cliqu?");
    }

}
