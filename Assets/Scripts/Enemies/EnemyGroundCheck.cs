using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGroundCheck : MonoBehaviour
{
    [SerializeField] public UnityEvent getNewPosition;

    // Update is called once per frame
    void Update()
    {
        CheckGroundRaycast();
    }

    private void CheckGroundRaycast()
    {
        RaycastHit checkGround;

        if (Physics.Raycast(transform.position, Vector3.down, out checkGround, 10f))
        {
            return;
        }
        else
            getNewPosition.Invoke();
    }
}
