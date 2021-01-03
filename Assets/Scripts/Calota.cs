using UnityEngine;


public class Calota : MonoBehaviour
{
    public bool beingBuilt, beingMelted;

    private void Start()
    {
        beingBuilt = false;
        beingMelted = false;
    }

    private void Update()
    {
        if (transform.position.y == 0f) beingBuilt = false;  
    }
}
