
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public enum CollectibleType
    {
        FIRE,
        WATER,
        HEALTH
    }

    public CollectibleType itemType;

    [HideInInspector]
    public string itemAction;

    // public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        switch(itemType)
        {
            case CollectibleType.FIRE:
                itemAction = "Press LMB to fire / Press F to discard the gun";
                break;

            case CollectibleType.WATER:
                itemAction = "Press LMB to fire / Press F to discard the gun";
                break;

            case CollectibleType.HEALTH:
                itemAction = "Press F to increase Health";
                break;
        }
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

  

   
    // Update is called once per frame
    void Update()
    {
        // Spin object around Y-Axis
        // transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
