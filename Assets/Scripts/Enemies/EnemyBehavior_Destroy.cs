using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Destroy : MonoBehaviour
{
    public int explosionCountLimit;
    public float timeToStartSeekExplosion;
    public float speed;
    public float idleTime = 2;
    public float deathTime = 1;

    [Header("VFXSamples")]
    public GameObject explosionVFXSample;
    public GameObject selfDestructionVFXSample;
    public GameObject deathSmokeVFXSample;
    public GameObject leftFootVFXSample;
    public GameObject rightFootVFXSample;

    private float goToX;
    private float goToZ;
    private float seekTimer;
    private bool deathState;
    private bool stopInPlaceCalled;
    private bool firstTimeStop = true;
    private int explosionCount = 0;

    private Vector3 nextPos;
    private GameObject iceChoosed;
    private Animator anim;
    private RaycastHit checkGround;
    private GameObject topRight;
    private GameObject bottomLeft;

    [System.Serializable]
    public class VFXPool
    {
        public string tag;
        public GameObject VFXPrefab;
        public int size;
    }

    [Header("DictonaryPools")]
    public List<VFXPool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        GameObject edges = GameObject.Find("Edges");
        topRight = edges.transform.Find("TopRight").gameObject;
        bottomLeft = edges.transform.Find("BottomLeft").gameObject;

        seekTimer = 0f;
        anim = GetComponent<Animator>();

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(VFXPool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.VFXPrefab);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
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
        if (iceChoosed != null && iceChoosed.transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().enabled == true)
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

    Vector3 OnTheMiddle(GameObject calota)
    {
        float x=0, z=0;
        Vector3 newPosition;

        for (int i = 0; i < calota.transform.childCount; i++)
        {
            x += calota.transform.GetChild(i).transform.position.x;
            z += calota.transform.GetChild(i).transform.position.z;
        }

        newPosition = new Vector3(x/calota.transform.childCount, transform.position.y, z/calota.transform.childCount);
        Debug.Log(newPosition);
        return newPosition;
    }

    private void ChooseIce()
    {
        GameObject calota = GameObject.Find("CalotaHexagonal");
        iceChoosed = calota.transform.GetChild(Random.Range(1, calota.transform.childCount - 1)).gameObject;
        Debug.Log("Ice Choosed: " + iceChoosed.name);
        // nextPos = new Vector3(iceChoosed.transform.localPosition.x, iceChoosed.transform.localPosition.y, iceChoosed.transform.localPosition.z);
        nextPos = OnTheMiddle(iceChoosed);
        Debug.Log("nextPos: " + nextPos);
        LookDirection(nextPos);

        anim.SetTrigger("Running");
    }

    private void MoveToIce()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        // Debug.Log("position: " + transform.position);
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
        FindObjectOfType<CalotasControllers>().DestroyCalota(iceChoosed);
        // iceChoosed.SetActive(false);
        // Debug.Log("Ice Choosed: " + iceChoosed.name);

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
        goToX = Random.Range(bottomLeft.transform.position.x, topRight.transform.position.x);
        goToZ = Random.Range(bottomLeft.transform.position.z, topRight.transform.position.z);

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
            collision.GetComponent<HitboxController>().ActivatePlayerHitVFX();
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

        DestroyAllVFXInstances();
        Destroy(gameObject);
    }

    private void DestroyAllVFXInstances()
    {
        
    }

    public bool GetDeathState()
    {
        return deathState;
    }

    public void InstanceExplosion()
    {
        GameObject newExplosion = poolDictionary["stompExplosion"].Dequeue();

        newExplosion.SetActive(true);
        newExplosion.transform.position = explosionVFXSample.transform.position;
        newExplosion.transform.eulerAngles = new Vector3(90f, transform.rotation.y, 0f);
        newExplosion.GetComponent<ParticleSystem>().Clear();
        newExplosion.GetComponent<ParticleSystem>().Play();

        poolDictionary["stompExplosion"].Enqueue(newExplosion);
        
        explosionCount++;
    }

    public void InstantiateFootstep(int whichSide)
    {
        if (poolDictionary == null)
        {
            return;
        }

        if (whichSide == 0) // direita
        {
            GameObject rightFoot = poolDictionary["rightFootstep"].Dequeue();

            rightFoot.SetActive(true);
            rightFoot.transform.position = rightFootVFXSample.transform.position;
            rightFoot.transform.eulerAngles = new Vector3(90f, transform.rotation.eulerAngles.y, 0f);
            rightFoot.GetComponent<ParticleSystem>().Clear();
            rightFoot.GetComponent<ParticleSystem>().Play();

            poolDictionary["rightFootstep"].Enqueue(rightFoot);
        }
        else if (whichSide == 1)
        {
            GameObject leftFoot = poolDictionary["leftFootstep"].Dequeue();

            leftFoot.SetActive(true);
            leftFoot.transform.position = leftFootVFXSample.transform.position;
            leftFoot.transform.eulerAngles = new Vector3(90f, transform.rotation.eulerAngles.y, 0f);
            leftFoot.GetComponent<ParticleSystem>().Clear();
            leftFoot.GetComponent<ParticleSystem>().Play();

            poolDictionary["leftFootstep"].Enqueue(leftFoot);
        }
        else
        {
            GameObject rightFoot = poolDictionary["rightFootstep"].Dequeue();

            rightFoot.SetActive(true);
            rightFoot.transform.position = rightFootVFXSample.transform.position;
            rightFoot.transform.eulerAngles = new Vector3(90f, transform.rotation.eulerAngles.y, 0f);
            rightFoot.GetComponent<ParticleSystem>().Clear();
            rightFoot.GetComponent<ParticleSystem>().Play();

            poolDictionary["rightFootstep"].Enqueue(rightFoot);

            GameObject leftFoot = poolDictionary["leftFootstep"].Dequeue();

            leftFoot.SetActive(true);
            leftFoot.transform.position = leftFootVFXSample.transform.position;
            leftFoot.transform.eulerAngles = new Vector3(90f, transform.rotation.eulerAngles.y, 0f);
            leftFoot.GetComponent<ParticleSystem>().Clear();
            leftFoot.GetComponent<ParticleSystem>().Play();

            poolDictionary["leftFootstep"].Enqueue(leftFoot);
        }
    }
}
