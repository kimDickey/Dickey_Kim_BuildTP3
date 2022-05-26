using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PointDeVie : MonoBehaviour
{
    public bool isGameOver { get; private set; } = false;
    public Transform feetPosition;
    public Transform player;
    public GameObject MenuMort;
    public GameObject menuVictoire;
    public GameObject txtVictoire;
    public Button btnQuitterPartie;
    public GameObject txtGameOver;
    
    public Text txtPointDeVie;

    int nbVie =5;
    
   
    void Start()
    {
        
        btnQuitterPartie.onClick.AddListener(btnQuitterPartie_Clicked);
        nbVie = int.Parse(txtPointDeVie.text);

    }

   

    // PROF: Le joueur ne devrait pas directement affecter le contenu du UI. Tu avais un UIManager, ce devrait être lui qui le fait. Ton joueur devrait envoyer l'information au UIManager
    public void OnCollisionEnter(Collision collision) 
    { 
        // si le joueur entre en collison avec les obstacles
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            // point de vie
            nbVie -= 1;
            txtPointDeVie.text = nbVie.ToString();
            
        }
        // si le nombre de point est égale 0 la partie est terminer
        if (nbVie == 0)
        {
            GameOver();
        }
        
    }
    void btnQuitterPartie_Clicked()
    {
        // fermer le menuMort
        MenuMort.SetActive(false);
        //charge la scene MenuAccueil
        SceneManager.LoadScene("Menu Accueil");
        //Affiche message dans la console quand il est cliqué
        Debug.Log("Bouton quitter partie à été cliqué");
    }
    // Fin de la partie
    public void GameOver()
    {

        isGameOver = true;
        // ouvre le menu mort
        MenuMort.SetActive(true);
        Time.timeScale = 0f;
    }
    private void FixedUpdate()
    {
        // vérifie si le joueur est dans le vide
        if(feetPosition.position.y <= -6f)
        {
            nbVie = 0;
            txtPointDeVie.text = nbVie.ToString();
            GameOver();
            
        }
        if (534f <= feetPosition.position.z)
        {
            Victoire();

        }

    }
    public void Victoire()
    {
        menuVictoire.SetActive(true);
        Time.timeScale = 0f;

    }
}
