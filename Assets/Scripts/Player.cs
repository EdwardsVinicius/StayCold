using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    //Teste gravidade
    public float gravityValue = -9.81f;
    private Vector3 playerVelocity;

    public float speed = 10f;
    private float turnMoveTime = .1f;
    private float turnMoveVelocity;
    private CharacterController controller;
    public GameObject hitbox;
    public GameObject dashHitbox;
    private bool slideEnabled = true;
    public float attackDuration = 0.3f;
    private float attackLag = 0f;

    [SerializeField]
    public int attackDamage = 25;

    [SerializeField]
    private int health = 100;

    private bool isMovable = true;
    public GameObject penguim;
    private Animator anim;
    private bool isDashing = false;
    public bool isDead = false;
    private float dashTime = -1;
    private float dashDuration = 0.3f;
    private bool immortal = false;

    private AudioSource[] sounds;

    public LifeSlider slider;

    InputManager controls;
    PlayerInput playerInput;
    Vector2 move;
    StartPoint script;

    private void Awake()
    {
        controls = new InputManager();

        GameObject startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        script = startPoint.GetComponent<StartPoint>();
        playerInput = GetComponent<PlayerInput>();

        if (script.isMultiplayer)
        {
            playerInput.SwitchCurrentActionMap("Player_1");

            controls.Player_1.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Player_1.Move.canceled += ctx => move = Vector2.zero;

            controls.Player_1.Attack.performed += ctx => Attack();
        }
        else
        {
            controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

            controls.Gameplay.Attack.performed += ctx => Attack();
        }

        //controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        //controls.Gameplay.Attack.performed += ctx => Attack();

    }

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("HolderPenguinHUD/Slider").GetComponent<LifeSlider>();

        controller = GetComponent<CharacterController>();
        anim = penguim.gameObject.GetComponent<Animator>();

        sounds = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Attack();
        Slide();
    }

    private void Move()
    {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(move.x, 0f, move.y).normalized;

        if (direction.magnitude > 0.1f && isMovable && !isDead)
        {
            anim.SetBool("running", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnMoveVelocity, turnMoveTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else
            anim.SetBool("running", false);


        //Teste Gravidade
        //Debug.Log(playerVelocity);
        playerVelocity.y = gravityValue;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    private void Attack()
    {
        //inserir bottão de ataque
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //}
        sounds[0].Play();
        StartCoroutine(ShowHitboxForSeconds());
    }

    private void Slide()
    {
        if (dashTime>=0)
        {
            controller.Move(transform.TransformDirection(Vector3.forward) * speed * 3 * Time.deltaTime);
            dashTime -= Time.deltaTime;
        }
        else
        {
            bool special;
            if (script.isMultiplayer)
            {
                special = controls.Player_1.Special.triggered;
            }
            else
            {
                special = controls.Gameplay.Special.triggered;
            }

            if (special && slideEnabled)
            {
                sounds[1].Play();

                isMovable = false;
                anim.SetBool("dashing", true);
                dashHitbox.SetActive(true);
                isDashing = true;
                dashTime = dashDuration;
                immortal = true;
                
            }
            else
            {

                immortal = false;
                isMovable = true;
                dashHitbox.SetActive(false);    
                anim.SetBool("dashing", false);
            }
            
        }
        
    }

    IEnumerator DashHelper()
    {        
        //transform.TransformDirection(Vector3.forward)*moveSpeed
        yield return new WaitForSeconds(1);
        isMovable = true;
        anim.SetBool("dashing", false);
    }

    IEnumerator DashCounter()
    {
        yield return new WaitForSeconds(1);
        isDashing = false;

    }


    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision entered");
        if (collision.gameObject.tag == "Enemy" && !immortal)
        {
            sounds[2].Play();
            anim.SetTrigger("damage");
            LoseHealth(attackDamage);
            //slider.SetHealth(health);
            if (health <= 0)
            {
                anim.SetBool("death", true);
                isDead = true;
                speed = 0;
            }
        }
        else if (collision.gameObject.tag == "Water")
        {
            LoseHealth(100);
            slider.SetHealth(health);
            if (health <= 0)
            {
                anim.SetBool("death", true);
                isDead = true;
                speed = 0;
            }
        }

    }
    
    IEnumerator ShowHitboxForSeconds()
    {
        //yield return new WaitForSeconds(attackLag);
        //isMovable = false;
        anim.SetTrigger("attack");
        speed /= 3;
        hitbox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        hitbox.SetActive(false);
        //isMovable = true;
        speed *= 3;
    }

    private void LoseHealth(int amount)
    {
        health -= amount;
    }

    private void OnEnable()
    {
        if (script.isMultiplayer)
        {
            controls.Player_1.Enable();
        }
        else
        {
            controls.Gameplay.Enable();
        }
    }

    private void OnDisable()
    {
        if (script.isMultiplayer)
        {
            controls.Player_1.Disable();
        }
        else
        {
            controls.Gameplay.Disable();
        }
    }

    //    void OnMove(CallbackContext context)
    //    {
    //        move = context.ReadValue<Vector2>();
    //    }

    //    void OnAttack(CallbackContext context)
    //    {
    //        Attack();
    //    }
}