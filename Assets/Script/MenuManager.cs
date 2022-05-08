using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button btnJouer;
    public Button btnParametre;
    public Button btnQuitter;
    public Button btnInstructions;
    public GameObject menuParametre;
    public GameObject menuInstructions;
    // Start is called before the first frame update
    void Start()
    {
        btnJouer.onClick.AddListener(btnJouer_Clicked);
        btnParametre.onClick.AddListener(btnParametre_Clicked);
        btnInstructions.onClick.AddListener(btnInstructions_Clicked);
        btnQuitter.onClick.AddListener(btnQuitter_Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btnJouer_Clicked()
    {
        //Affiche message dans la console quand il est cliqu�
        Debug.Log("Bouton jouer � �t� cliqu�");
    }

    // affiche le menu des parametre
    void btnParametre_Clicked()
    {
        menuParametre.SetActive(true);
        Debug.Log("Bouton param�tre � �t� cliqu�");
    }
    // affiche le menu d'intructions
    void btnInstructions_Clicked()
    {
        menuInstructions.SetActive(true);
        Debug.Log("Bouton instructions � �t� cliqu�");
    }
    void btnQuitter_Clicked()
    {
        //Affiche message dans la console quand il est cliqu�
        Debug.Log("Bouton quitter � �t� cliqu�");
    }
}
