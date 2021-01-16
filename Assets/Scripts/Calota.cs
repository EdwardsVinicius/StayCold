using UnityEngine;

public class Calota : MonoBehaviour
{
    public static float builtPosition, meltedPosition;
    public bool beingBuilt, beingMelted, willBeDestroyed;

    private void Start()
    {
        beingBuilt = false;
        beingMelted = false;
        willBeDestroyed = false;
        builtPosition = gameObject.transform.localPosition.y;
        // Debug.Log(gameObject.name + " y: " + builtPosition);
        meltedPosition = builtPosition - 10;
    }

    private void Update()
    {
        // Debug.Log(name + ": " + transform.localPosition.y);
        if (transform.localPosition.y == builtPosition) beingBuilt = false;
    }
}
