using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Fly : MonoBehaviour
{
    [Header("Floating")]
    public float speed;
    public float timeBetwweenShoots = 1.5f;
    public float timeToTurnWhenAboveWater = 2f;
    public float upDistance = 10f;
    public int roundsBeforeLanding = 3;

    [Header("When Landing")]
    public bool random;
    public bool seek;
    public bool shoot;
    public bool destroy;

    [Header("ShootGround")]
    public float projectileSpeed;

    private float initialY;
    private float roundsCount = 0;
    private float shootTimer = 0;
    
    private bool aboveWater;

    private Animator anim;
    private EnemyBehavior_Instantiate shootComponent;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        aboveWater = true;

        shootComponent = GetComponent<EnemyBehavior_Instantiate>();

        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");

        initialY = transform.position.y;
        transform.position = new Vector3(transform.position.x, initialY + upDistance, transform.position.z);

        ChangeDirectionToNearstPlayer(upDistance);
        transform.position -= direction * 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime;
        CheckSurfaceBelow();
    }

    private void ChangeDirectionToNearstPlayer(float upY)
    {
        if (upY == 0)
        {
            transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
        }

        Transform nearPlayer = ClosestPlayer();
        direction = (new Vector3(nearPlayer.transform.position.x, initialY + upY, nearPlayer.transform.position.z) - transform.position).normalized * speed;
        LookDirection();
    }

    private Transform ClosestPlayer()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players == null)
            return null;

        GameObject closest = null;
        float distance = Mathf.Infinity;

        Vector3 position = transform.position;

        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }

        return closest.transform;
    }

    private void LookDirection()
    {
        Vector3 directionAngle = (direction - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(directionAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f);
    }

    private void CheckSurfaceBelow()
    {
        RaycastHit groundBelow;
        if (Physics.Raycast(transform.position, Vector3.down, out groundBelow, 12f))
        {
            if (aboveWater)
            {
                if (roundsCount >= roundsBeforeLanding)
                {
                    EnemyGroundBehavior();
                }
                aboveWater = false;
                shootComponent.enabled = true;
            }

            shootTimer += Time.deltaTime;

            if (shootTimer >= timeBetwweenShoots)
            {
                shootComponent.TriggerFireInstance();
                shootTimer = 0;
            }
        }
        else
        {
            if (!aboveWater)
            {
                shootTimer = 0;

                aboveWater = true;
                shootComponent.enabled = false;

                StartCoroutine(PrepareTurn());
                roundsCount++;
            }
        }
    }

    IEnumerator PrepareTurn()
    {
        yield return new WaitForSeconds(timeToTurnWhenAboveWater);

        if(roundsCount >= roundsBeforeLanding)
        {
            ChangeDirectionToNearstPlayer(0);
        }
        else
        {
            ChangeDirectionToNearstPlayer(upDistance);
        }
    }

    private void EnemyGroundBehavior()
    {
        if (random)
        {
            GetComponent<EnemyBehavior_Random>().enabled = true;
            GetComponent<EnemyBehavior_Random>().AttachToGroundCheck();
        }
        else if (seek)
        {
            GetComponent<EnemyBehavior_Seek>().enabled = true;
        }
        else if (shoot)
        {
            GetComponent<EnemyBehavior_Shoot>().enabled = true;
            GetComponent<EnemyBehavior_Shoot>().AttachToGroundCheck();

            GetComponent<EnemyBehavior_Instantiate>().seekNearestPlayer = true;
            GetComponent<EnemyBehavior_Instantiate>().applyGravity = false;
            GetComponent<EnemyBehavior_Instantiate>().speed = projectileSpeed;

        }
        else if (destroy)
        {
            GetComponent<EnemyBehavior_Destroy>().enabled = true;
            GetComponent<EnemyBehavior_Destroy>().AttachToGroundCheck();
        }

        anim.SetTrigger("Running");
        GetComponent<EnemyBehavior_Fly>().enabled = false;
    }

        private void StartDestroy()
    {
        Destroy(gameObject);
    }
}
