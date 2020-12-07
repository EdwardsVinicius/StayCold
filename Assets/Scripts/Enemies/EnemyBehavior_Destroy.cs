using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Destroy : MonoBehaviour
{
    public float timeToStartSeekExplosion;
    public int explosionCountLimit;

    public float speed;
    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;
    public float idleTime = 2;
    public float deathTime = 1;
    public GameObject explosionVFXSample;
    public GameObject selfDestructionVFXSample;
    public GameObject deathSmokeVFXSample;

    public GameObject leftFootVFXSample;
    public GameObject rightFootVFXSample;

    private float goToX;
    private float goToZ;
    private float seekTimer;
    private int explosionCount = 0;
    private Vector3 nextPos;
    private GameObject iceChoosed;
    private bool deathState;
    private bool stopInPlaceCalled;
    private bool firstTimeStop = true;

    private Animator anim;

    private RaycastHit checkGround;

    // Start is called before the first frame update
    void Start()
    {
        seekTimer = 0f;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathState || stopInPlaceCalled)
            return;

        if(seekTimer < timeToStartSeekExplosion)
        {
            seekTimer += Time.deltaTime;
            if (transform.position == nextPos || nextPos == Vector3.zero)
            {
                StartCoroutine(StopInPlace());
            }

            CheckGroundRaycast();
        }
        else
        {
            GoToIce();
        }
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

    private void GoToIce()
    {
        if(iceChoosed != null && iceChoosed.activeSelf == true)
        {
            if(transform.position == nextPos)
            {
                DetonationCountdown();
            }
            else
            {
                MoveToIce();
            }
        }
        else
        {
            StopAllCoroutines();
            stopInPlaceCalled = false;
            ChooseIce();
        }
    }

    private void ChooseIce()
    {
        GameObject calota = GameObject.Find("Calota");
        iceChoosed = calota.transform.GetChild(Random.Range(1, calota.transform.childCount - 1)).gameObject;
        nextPos = new Vector3(iceChoosed.transform.position.x, transform.position.y, iceChoosed.transform.position.z);
        LookDirection(nextPos);

        anim.SetTrigger("Running");
    }

    private void MoveToIce()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void DetonationCountdown()
    {
        anim.SetTrigger("Destroy");

        if (explosionCount >= explosionCountLimit)
        {
            StartDetonation();
        }
    }

    private void StartDetonation()
    {
        iceChoosed.SetActive(false);

        GameObject selfDesctructionExplosion = Instantiate(selfDestructionVFXSample, selfDestructionVFXSample.transform.position, selfDestructionVFXSample.transform.rotation);
        selfDesctructionExplosion.SetActive(true);
        selfDesctructionExplosion.transform.parent = GameObject.Find("ExplosionInstances").transform;

        Destroy(gameObject);
    }

    private void CheckGroundRaycast()
    {
        if (Physics.Raycast(nextPos, Vector3.down, out checkGround, 2f))
        {
            if (checkGround.transform.gameObject.tag == "Ground")
                transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

            else
                nextPos = GetNewPosition();
        }

        else
            nextPos = GetNewPosition();
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

        yield return new WaitForSeconds(0.15f);

        var eSC = FindObjectOfType<EnemySpawnController>();
        if(eSC != null)
            eSC.DecreaceEnemyCount();

        Destroy(gameObject);
    }

    public bool GetDeathState()
    {
        return deathState;
    }

    public void InstanceExplosion()
    {
        GameObject newExplosion = Instantiate(explosionVFXSample, explosionVFXSample.transform.position, explosionVFXSample.transform.rotation);
        newExplosion.SetActive(true);
        newExplosion.transform.parent = GameObject.Find("ExplosionInstances").transform;
        
        explosionCount++;
    }

    public void InstantiateFootstep(int whichSide)
    {
        if (whichSide == 0) // direita
        {
            GameObject rightFoot = Instantiate(rightFootVFXSample, rightFootVFXSample.transform.position, transform.rotation);
            rightFoot.transform.eulerAngles += new Vector3(90f, transform.rotation.y, 0f);
            rightFoot.SetActive(true);
        }
        else if (whichSide == 1)
        {
            GameObject leftFoot = Instantiate(leftFootVFXSample, leftFootVFXSample.transform.position, transform.rotation);
            leftFoot.transform.eulerAngles += new Vector3(90f, transform.rotation.y, 0f);
            leftFoot.SetActive(true);
        }
        else
        {
            GameObject rightFoot = Instantiate(rightFootVFXSample, rightFootVFXSample.transform.position, transform.rotation);
            rightFoot.transform.eulerAngles += new Vector3(90f, transform.rotation.y, 0f);
            rightFoot.SetActive(true);

            GameObject leftFoot = Instantiate(leftFootVFXSample, leftFootVFXSample.transform.position, transform.rotation);
            leftFoot.transform.eulerAngles += new Vector3(90f, transform.rotation.y, 0f);
            leftFoot.SetActive(true);
        }
    }
}
