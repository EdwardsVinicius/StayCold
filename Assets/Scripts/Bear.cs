using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Bear : MonoBehaviour
{
    public float speed = 10f;
    private float turnMoveTime = .1f;
    private float turnMoveVelocity;
    public float attackDuration = 0;
    public float hitboxDuration = 0.15f;
    private CharacterController controller;
    public bool isAttacking;

    //Teste gravidade
    public float gravityValue = -9.81f;
    private Vector3 playerVelocity;

    public bool hasSnowBall;
    public bool canPickUpSnowBall; // necessario para o cooldown do especial
    public float snowBallCoolDownDuration;
    public float throwForce;
    public GameObject snowBall;
    public Rigidbody throwableSnowBall;
    public Transform snowBallSpawn;

    public GameObject hitbox;
    public int health = 100;
    public bool dead;

    public GameObject bear;
    private Animator anim;

    private AudioSource[] sounds;

    public LifeSlider slider;
    // public RebuiltIce rebuiltIce;

    //private UIController _uiController;
    InputManager controls;
    PlayerInput playerInput;
    Vector2 move;
    StartPoint script;

    [SerializeField]
    private int playerIndex = 1;

    private bool special;

    private void Awake()
    {
        controls = new InputManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        //_uiController = GameObject.Find("UIController").GetComponent<UIController>();
        canPickUpSnowBall = true;
        dead = false;
        hasSnowBall = false;
        special = false;
        isAttacking = false;

        controller = GetComponent<CharacterController>();
        sounds = GetComponents<AudioSource>();
        anim = bear.gameObject.GetComponent<Animator>();
        slider = GameObject.Find("HolderBearHUD/Slider").GetComponent<LifeSlider>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, -1.32f, transform.position.z);
        if (!dead)
        {
            Move();
            if (!hasSnowBall && canPickUpSnowBall)
            {
                PickUpSnow();
            }
            else if (hasSnowBall)
            {
                PlaceSnow();
            }
            //Attack();
        }

    }

    private void Move()
    {
        Vector3 direction = new Vector3(move.x, 0f, move.y).normalized;

        if (direction.magnitude > 0.1f)
        {
            anim.SetBool("bearRunning", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnMoveVelocity, turnMoveTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("bearRunning", false);
        }

        //Teste Gravidade
        //Debug.Log(playerVelocity);
        playerVelocity.y = gravityValue;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void PickUpSnow()
    {
        if (special && !hasSnowBall)
        {
            sounds[0].Play();
            hasSnowBall = true;
            snowBall.SetActive(true);
            anim.SetBool("bearHasSnowBall", true);
            //Debug.Log("snow ball " + hasSnowBall.ToString());
        }

        special = false;
    }

    public IEnumerator SnowBallCoolDown(float time)
    {
        canPickUpSnowBall = false;
        yield return new WaitForSeconds(time);

        canPickUpSnowBall = true;
    }

    private void PlaceSnow()
    {
        if (special && hasSnowBall)
        {

            //Setar animator throwing
            hasSnowBall = false;
            snowBall.SetActive(false);

            Rigidbody throwableSnowBallInstance;
            throwableSnowBallInstance = Instantiate(throwableSnowBall, snowBallSpawn.position, snowBallSpawn.rotation) as Rigidbody;
            throwableSnowBallInstance.AddForce(snowBallSpawn.up * throwForce);

            anim.SetBool("bearHasSnowBall", false);
            anim.SetTrigger("bearThrow");
            //StartCoroutine(ShowHitboxForSeconds(attackDuration));            
        }

        special = false;
    }

    private void Attack()
    {
        if (hasSnowBall && !dead)
        {
            //Setar animator attack
            isAttacking = true;
            sounds[1].Play();
            // anim.SetTrigger("bearAttack");

            //Setar animator throwing
            hasSnowBall = false;
            snowBall.SetActive(false);

            Rigidbody throwableSnowBallInstance;
            throwableSnowBallInstance = Instantiate(throwableSnowBall, snowBallSpawn.position, snowBallSpawn.rotation) as Rigidbody;
            throwableSnowBallInstance.AddForce(snowBallSpawn.up * throwForce);

            
            anim.SetBool("bearHasSnowBall", false);
            anim.SetTrigger("bearThrow");
            // StartCoroutine(TriggerIsAttackingBool());
            // isAttacking = false;
        }
    }

    /*
    IEnumerator TriggerIsAttackingBool()
    {
        // isAttacking = true;
        yield return new WaitForSeconds(attackDuration);
        isAttacking = false;
    }
    */


    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Collision entered");
        // quando colide com o inimigo isso acontece
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.tag == "Projectile")
        {
            Debug.Log("Collision entered");
            if (!isAttacking) LoseHealth(25);
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            LoseHealth(100);
            FindObjectOfType<ScoreController>().GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Quando ela ataca isso acontece
        // Debug.Log("Colidindo com: " + other);
        if (other.gameObject.CompareTag("Enemy"))
        {
            sounds[1].Play();
            // LoseHealth(25);
        }
        else if (other.gameObject.CompareTag("Ground") && other.gameObject.GetComponent<MeshRenderer>().enabled == false)
        {
            // Debug.Log("Colidindo com calota derretida");
            StartCoroutine(DisableMeshCollider(other));
        }

    }

    // Desabilita o Mesh Collider da calota por 2 segundos
    IEnumerator DisableMeshCollider(Collider calota)
    {
        calota.gameObject.GetComponent<MeshCollider>().enabled = false;
        yield return new WaitForSeconds(2f);
        calota.gameObject.GetComponent<MeshCollider>().enabled = true;
    }

    public void ActivateHitbox()
    {
        StartCoroutine(ShowHitboxForSeconds());
    }

    public IEnumerator ShowHitboxForSeconds()
    {
        hitbox.SetActive(true);
        yield return new WaitForSeconds(hitboxDuration);
        hitbox.SetActive(false);
    }

    private void LoseHealth(int amount)
    {
        
        Debug.Log("Lost Health");

        health -= amount;
        if (health < 0)
        {
            health = 0;
        }
        slider.SetHealth(health);
        if (health > 0)
        {
            sounds[2].Play();
            anim.SetTrigger("bearDamage");
        }
        if (health <= 0 && !dead)
        {
            Death();
        }
    }

    private void Death()
    {
        anim.SetBool("bearRunning", false);
        anim.SetBool("bearHasSnowBall", false);
        snowBall.SetActive(false);
        dead = true;
        anim.SetTrigger("bearDeath");
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    private void OnEnable()
    {
        //if (script.isMultiplayer)
        //{
        //    controls.Player_2.Enable();
        //}
        //else
        //{
        //    controls.Gameplay.Enable();
        //}
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        //if (script.isMultiplayer)
        //{
        //    controls.Player_2.Disable();
        //}
        //else
        //{
        //    controls.Gameplay.Disable();
        //}
        controls.Gameplay.Disable();
    }

    public void OnMove(CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnAttack(CallbackContext context)
    {
        if (context.performed) Attack();
    }

    public void OnSpecial(CallbackContext context)
    {
        if (context.performed) special = true;
    }
}

