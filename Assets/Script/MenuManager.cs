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
    public Button btnQuitterInstructions;
    public Button btnInstructions;
    public Button btnQuitterParametre;
    public GameObject menuParametre;
    public GameObject menuInstructions;
    // Start is called before the first frame update
    void Start()
    {
        btnJouer.onClick.AddListener(btnJouer_Clicked);
        btnParametre.onClick.AddListener(btnParametre_Clicked);
        btnInstructions.onClick.AddListener(btnInstructions_Clicked);
        btnQuitterInstructions.onClick.AddListener(btnQuitterInstructions_Clicked);
        btnQuitterParametre.onClick.AddListener(btnQuitterParametre_Clicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btnJouer_Clicked()
    {
        //charge la scene Main
        SceneManager.LoadScene("Main");
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
    void btnQuitterInstructions_Clicked()
    {
        //fermer le menu instructions
        menuInstructions.SetActive(false);
        //Affiche message dans la console quand il est cliqu�
        Debug.Log("Bouton quitter � �t� cliqu�");
    }
    void btnQuitterParametre_Clicked()
    {
        // fermer le menuParametre
        menuParametre.SetActive(false);
        //Affiche message dans la console quand il est cliqu�
        Debug.Log("Bouton quitter � �t� cliqu�");
    }
}
