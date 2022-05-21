using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    private bool turnLeft, turnRight, jump;
    public float speed = 7.0f;
    private CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // pour aller à gauche
        turnLeft = Input.GetKeyDown(KeyCode.A);
        // pour aller à droite
        turnRight = Input.GetKeyDown(KeyCode.D);

        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));

        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move(transform.forward * speed * Time.deltaTime);

        // permet au joueur de sauter
        jump = Input.GetKeyDown(KeyCode.Space);
   
       
    }
}
