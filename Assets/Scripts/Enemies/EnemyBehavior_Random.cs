using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Random : MonoBehaviour
{
    public float speed;
    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;
    public float idleTime = 2;
    public float deathTime = 1;
    public GameObject deathSmokeVFXSample;

    private float idleTimePassed = 0;
    private float goToX;
    private float goToZ;
    private Vector3 nextPos;
    private bool deathState;
    private bool stopInPlaceCalled;
    private bool firstTimeStop = true;

    private RaycastHit checkGround;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathState || stopInPlaceCalled)
        {
            return;
        }

        if (transform.position == nextPos || nextPos == Vector3.zero)
        {
            StartCoroutine(StopInPlace());
        }

        CheckGroundRaycast();
    }

    private void CheckGroundRaycast()
    {
        if (nextPos != Vector3.positiveInfinity && Physics.Raycast(nextPos, Vector3.down, out checkGround, 2f))
        {
            if (checkGround.transform.gameObject.tag == "Ground")
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            else
                nextPos = GetNewPosition();
        }

        else
            nextPos = GetNewPosition();
    }

    IEnumerator StopInPlace()
    {
        stopInPlaceCalled = true;

        anim.SetTrigger("Idle");

        if (!firstTimeStop)
            yield return new WaitForSeconds(idleTime);

        else
            firstTimeStop = false;
        
        anim.SetTrigger("Running");

        nextPos = GetNewPosition();

        stopInPlaceCalled = false;
    }

    private Vector3 GetNewPosition()
    {
        goToX = Random.Range(minX, maxX);
        goToZ = Random.Range(minZ, maxZ);

        Vector3 newPos = new Vector3(goToX, transform.position.y, goToZ);

        RaycastHit newGroundCheck;

        if (Physics.Raycast(newPos, Vector3.down, out newGroundCheck, 2f))
        {
            if (newGroundCheck.transform.gameObject.tag == "Ground")
            {
                LookDirection(newPos);
                return newPos;
            }

            else
                return Vector3.positiveInfinity;
        }

        else
            return Vector3.positiveInfinity;
    }

    private void LookDirection(Vector3 newPos)
    {
        Vector3 direction = (newPos - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f);

        transform.eulerAngles += new Vector3(0f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Hitbox")
        {
            StartCoroutine(ActiveDeathState());
        }
    }

    IEnumerator ActiveDeathState()
    {
        anim.SetTrigger("Death");
        deathState = true;
        yield return new WaitForSeconds(deathTime);

        GameObject deathSmoke = Instantiate(deathSmokeVFXSample, deathSmokeVFXSample.transform.position, deathSmokeVFXSample.transform.rotation);
        deathSmoke.SetActive(true);
        deathSmoke.transform.parent = GameObject.Find("ExplosionInstances").transform;

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);
    }

    public bool GetDeathState()
    {
        return deathState;
    }
}