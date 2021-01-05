using UnityEngine;

public class ThrowableSnowBall : MonoBehaviour
{

    public float fallMultiplier = 16.0f;

    CalotasControllers calotasControllers;

    Rigidbody rb;

    void Awake(){
        rb = GetComponent<Rigidbody>();
        calotasControllers = FindObjectOfType<CalotasControllers>().GetComponent<CalotasControllers>();
    }

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
            GameObject calota = collider.transform.parent.gameObject;
            Debug.Log("colisao com Ground " + calota.name);
            calotasControllers.RebuildingCalota(calota);
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.CompareTag("Water"))
        {
            Destroy(this.gameObject);
        }

    }
}
