using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Seek : MonoBehaviour
{
    public float speed;
    public float deathTime = 1;

    private bool deathState;

    private Vector3 playerYCorretion;

    [Header("VFXSamples")]
    public GameObject deathSmokeVFXSample;
    public GameObject leftFootVFXSample;
    public GameObject rightFootVFXSample;

    private Animator anim;

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

    private void Start()
    {
        anim = GetComponent<Animator>();

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (VFXPool pool in pools)
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
        if (deathState)
            return;

        Transform nearestPlayer = ClosestPlayer();

        if(nearestPlayer != null)
        {
            playerYCorretion = new Vector3(nearestPlayer.position.x, transform.position.y, nearestPlayer.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerYCorretion, speed * Time.deltaTime);

            LookDirection();
        }
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
        Vector3 direction = (playerYCorretion - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f);

        transform.eulerAngles += new Vector3(0f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Hitbox"))
        {
            if (anim == null) return;

            HitboxController hitboxController = collision.GetComponent<HitboxController>();

            if (hitboxController != null) hitboxController.ActivatePlayerHitVFX();
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
        if (eSC != null)
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
        else
        {
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
