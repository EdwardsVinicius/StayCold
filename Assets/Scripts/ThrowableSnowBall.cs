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
        if (collider.gameObject.CompareTag("Ground"))
        {
            Debug.Log("colisao com Ground " + collider.transform.parent.gameObject.name);
            rebuilt.rebuiltPlatform(collider.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.CompareTag("Water"))
        {
            if (rebuilt == null)
                return;
            Debug.Log("colisao com Water");
            // rebuilt.rebuiltPlatform();
            Destroy(this.gameObject);
        }

    }
}
