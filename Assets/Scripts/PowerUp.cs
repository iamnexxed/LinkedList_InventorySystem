using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fireRate = 10;
    public GameObject waterEffect;
    public GameObject fireEffect;
    public GameObject lightningEffect;

    // Update is called once per frame
    void Update()
    {
        if (PlayerInventory.hasNoItems)
            return;

        if (Input.GetMouseButton(0))
        {
            // Fire
            switch (PlayerInventory.currentItem.itemType)
            {
                case Collectibles.CollectibleType.FIRE:
                    // Debug.Log("Shoot Fire");
                    StartCoroutine(Shoot(fireEffect));
                    break;

                case Collectibles.CollectibleType.WATER:
                    StartCoroutine(Shoot(waterEffect));
                    // Debug.Log("Shoot Water");
                    break;

                case Collectibles.CollectibleType.HEALTH:
                    
                    break;

                default: // Debug.Log("Shoot nothing.");
                    break;
            }
        }
        
    }


    IEnumerator Shoot(GameObject effectObject)
    {
        
       GameObject newEffect = Instantiate(effectObject, transform.position, effectObject.transform.rotation);
        newEffect.transform.SetParent(transform);
       
        yield return new WaitForSeconds(0.5f);
        Destroy(newEffect);
    }
   
}
