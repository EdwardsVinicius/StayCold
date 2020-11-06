using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Destroy : MonoBehaviour
{
    public float timeToStartSeekExplosion;
    public float timeToExplode;

    public float speed;
    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;

    private float goToX;
    private float goToZ;
    private float seekTimer;
    private float explosionTimer;
    private Vector3 nextPos;
    private GameObject iceChoosed;

    private RaycastHit checkGround;

    // Start is called before the first frame update
    void Start()
    {
        seekTimer = 0f;
        explosionTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(seekTimer < timeToStartSeekExplosion)
        {
            seekTimer += Time.deltaTime;
            if (transform.position == nextPos || nextPos == Vector3.zero)
            {
                nextPos = GetNewPosition();
                LookDirection();
            }

            CheckGroundRaycast();
        }
        else
        {
            GoToIce();
        }
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
            ChooseIce();
        }
    }

    private void ChooseIce()
    {
        GameObject calota = GameObject.Find("Calota");
        iceChoosed = calota.transform.GetChild(Random.Range(1, calota.transform.childCount - 1)).gameObject;
        nextPos = new Vector3(iceChoosed.transform.position.x, transform.position.y, iceChoosed.transform.position.z);
    }

    private void MoveToIce()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void DetonationCountdown()
    {
        explosionTimer += Time.deltaTime;

        if(explosionTimer >= timeToExplode)
        {
            StartDetonation();
        }
    }

    private void StartDetonation()
    {
        iceChoosed.SetActive(false);
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
                return newPos;

            else
                return GetNewPosition();
        }

        else
            return GetNewPosition();
    }

    private void LookDirection()
    {
        Vector3 direction = (nextPos - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f);

        transform.eulerAngles += new Vector3(0f, 180f, 0f);
    }
}
