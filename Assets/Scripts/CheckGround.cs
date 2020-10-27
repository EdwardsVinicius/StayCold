using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private Vector3 groundPosition;
    private Vector3 diference;
    private Vector3 newDiference;

    public float checkDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit groundCheck;

        if (Physics.Raycast(transform.position, Vector3.down, out groundCheck, checkDistance))
        {
            if (groundCheck.transform.gameObject.tag == "Ground")
            {
                groundPosition = groundCheck.transform.position;
                diference = groundPosition - transform.position;
                newDiference = diference;
            }
        }
        else
        {
            SelfDeactive();
        }

    }

    private void Update()
    {
        CheckIfThereIsGround();
    }

    private void CheckIfThereIsGround()
    {
        RaycastHit groundCheck;

        if (Physics.Raycast(transform.position, Vector3.down, out groundCheck, checkDistance))
        {
            if (groundCheck.transform.gameObject.tag == "Ground")
            {
                groundPosition = groundCheck.transform.position;
                newDiference = groundPosition - transform.position;

                if(diference[1] - newDiference[1] != 0)
                {
                    transform.position += newDiference - diference;
                }
            }
        }

        else
        {
            SelfDeactive();
        }
    }

    private void SelfDeactive()
    {
        gameObject.SetActive(false);
    }
}
