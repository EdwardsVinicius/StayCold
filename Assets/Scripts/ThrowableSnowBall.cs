using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSnowBall : MonoBehaviour
{

    public float fallMultiplier = 16.0f;

    public RebuiltIce rebuilt;

    Rigidbody rb;
    // Start is called before the first frame update

    void Awake(){
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.y < 0){
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {

        //Debug.Log("Collision entered");
        if (collider.gameObject.tag == "Ground")
        {
            Debug.Log("colisao com Ground");
            //rebuilt.rebuiltPlatform();
            Destroy(this.gameObject);
        }


        else if (collider.gameObject.tag == "Water")
        {
            if (rebuilt == null)
                return;
            Debug.Log("colisao com Water");
            rebuilt.rebuiltPlatform();
            Destroy(this.gameObject);
        }

    }
}
