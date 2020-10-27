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

    private float goToX;
    private float goToZ;
    private Vector3 nextPos;

    private RaycastHit checkGround;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == nextPos || nextPos == Vector3.zero)
        {
            nextPos = GetNewPosition();
            LookDirection();
        }

        CheckGroundRaycast();
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

        if(Physics.Raycast(newPos, Vector3.down, out newGroundCheck, 2f))
        {
            if(newGroundCheck.transform.gameObject.tag == "Ground")
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