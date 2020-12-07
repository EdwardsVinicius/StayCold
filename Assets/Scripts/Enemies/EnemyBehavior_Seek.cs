using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Seek : MonoBehaviour
{
    public float speed;
    public float deathTime = 1;

    private bool deathState;

    private Vector3 playerYCorretion;

    public GameObject deathSmokeVFXSample;
    public GameObject leftFootVFXSample;
    public GameObject rightFootVFXSample;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Running");
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
        if (eSC != null)
            eSC.DecreaceEnemyCount();

        Destroy(gameObject);
    }

    public bool GetDeathState()
    {
        return deathState;
    }

    public void InstantiateFootstep(int whichSide)
    {
        if (whichSide == 0) // direita
        {
            GameObject rightFoot = Instantiate(rightFootVFXSample, rightFootVFXSample.transform.position, transform.rotation);
            rightFoot.transform.eulerAngles += new Vector3(90f, transform.rotation.y, 0f);
            rightFoot.SetActive(true);
        }
        else
        {
            GameObject leftFoot = Instantiate(leftFootVFXSample, leftFootVFXSample.transform.position, transform.rotation);
            leftFoot.transform.eulerAngles += new Vector3(90f, transform.rotation.y, 0f);
            leftFoot.SetActive(true);
        }
    }
}
