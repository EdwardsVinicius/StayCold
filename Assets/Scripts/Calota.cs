using UnityEngine;


public class Calota : MonoBehaviour
{
    public static float builtPosition, meltedPosition;
    public bool beingBuilt, beingMelted;

    private void Start()
    {
        beingBuilt = false;
        beingMelted = false;
        builtPosition = gameObject.transform.localPosition.y;
        // Debug.Log(gameObject.name + " y: " + builtPosition);
        meltedPosition = builtPosition - 10;
    }

    private void Update()
    {
        if (transform.position.y == builtPosition) beingBuilt = false;  
    }
}
