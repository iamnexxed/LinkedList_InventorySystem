using UnityEngine.UI;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject activeItemText;
    public Text itemsText;
    public Text actionText;
    public GameObject pickupText;
    InventoryLinkedList playerInventory;
    InventoryLinkedList.Iterator it;


    public static Collectibles currentItem;
    public static bool hasNoItems;
    // Start is called before the first frame update
    void Start()
    {
        playerInventory = new InventoryLinkedList();
        it = new InventoryLinkedList.Iterator();
        currentItem = null;
        hasNoItems = true;
        activeItemText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerInventory.Empty())
        {
            activeItemText.SetActive(true);
            hasNoItems = false;
            it = playerInventory.Begin();

            string inventoryText = "";
            for (uint i = 0; i < playerInventory.Size(); i++, it++)
            {
                inventoryText += "    " + it.node.gameObject.name ;
            }
            itemsText.text = inventoryText;

            currentItem = playerInventory.Front().GetComponent<Collectibles>();
            actionText.text = currentItem.itemAction;

            if (Input.GetKeyDown(KeyCode.F))
            {
                if(currentItem.itemType == Collectibles.CollectibleType.HEALTH)
                {
                    GameManager.instance.health += 50;
                    Debug.Log("Health Increased!");
                }
                RemoveObject();

            }

           
        }
        else
        {
            itemsText.text = "";
            actionText.text = "";
            currentItem = null;
            hasNoItems = true;
            activeItemText.SetActive(false);
        }
            
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            pickupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            pickupText.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
       if(other.CompareTag("Collectible"))
        {
            // Debug.Log("Should Pickup.");
            if (Input.GetKey(KeyCode.E))
            {
                pickupText.SetActive(false);
                AddObject(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }
       
    }

    void AddObject(GameObject newObject)
    {
        playerInventory.Push_back(newObject);
        Debug.Log("Player has number of items : " + playerInventory.Size());
    }

    void RemoveObject()
    {
        playerInventory.Pop_front();
        Debug.Log("Player has number of items : " + playerInventory.Size());
    }
}
