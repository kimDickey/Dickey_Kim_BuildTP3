using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float walkingSpeed = 5f;
    public float runningSpeed = 7f;
    private float animationSpeed = 1f;
    private float lerpspeed = 0.08f;
    float speed = 7f;
    public AudioSource crisSaut;
    
    public float  jumpHeight =1f;
   

    // Transform de la position des pieds
    public Transform feetPosition;

    private float inputVertical;
    private float inputHorizontal;

    private Vector3 moveDirection;

    private Rigidbody rb;

    private bool isGrounded = true;

    private Animator animatorPlayer;

    bool isMoving;



    private void Awake()
    {
        crisSaut = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
       

        // assignrt l'animator
        animatorPlayer = GetComponent<Animator>();
        //Assigner le rigidbody
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifier si l'on touche le sol
        isGrounded = Physics.CheckSphere(feetPosition.position, 0.15f, 1, QueryTriggerInteraction.Ignore);
        // Vérifier les inputs du joueur
        // Vertical (W, S et Joystick avant/arrière)
        inputVertical = Input.GetAxis("Vertical");
        // Horizontal (A, D et Joystick gauche/droite)
        inputHorizontal = Input.GetAxis("Horizontal");
        

        isMoving = Mathf.Abs(inputHorizontal) + Mathf.Abs(inputVertical) > 0f;

        
        // animation
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animationSpeed = Mathf.Lerp(animationSpeed, 2f, lerpspeed);

            speed = Mathf.Lerp(speed, runningSpeed, lerpspeed);
        }
        // marcher
        else
        {

            animationSpeed = Mathf.Lerp(animationSpeed, 1f, lerpspeed);
            speed = Mathf.Lerp(speed, walkingSpeed, lerpspeed);


        }
        // la fluiditer des mouvements dans les animations
        animatorPlayer.SetFloat("Vertical", inputVertical * animationSpeed);
        animatorPlayer.SetFloat("Horizontal", inputHorizontal * animationSpeed);
        // Vecteur de mouvements (Avant/arrière + Gauche/Droite)
        moveDirection = transform.forward * inputVertical + transform.right * inputHorizontal;
        //Sauter
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            crisSaut.Play();
            animatorPlayer.SetTrigger("Jump");
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }



    }




    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}
