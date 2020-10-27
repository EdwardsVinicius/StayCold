using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Fly : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = (new Vector3(0f, transform.position.y, 0f) - transform.position).normalized * speed;
        LookDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime;
        timeToDestroy -= Time.deltaTime;

        if (timeToDestroy < 0)
        {
            StartDestroy();
        }
    }

    private void StartDestroy()
    {
        Destroy(gameObject);
    }

    private void LookDirection()
    {
        Vector3 directionAngle = (direction - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(directionAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f);

        transform.eulerAngles += new Vector3(0f, 180f, 0f);
    }
}
