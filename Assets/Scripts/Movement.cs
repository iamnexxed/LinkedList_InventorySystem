

using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public float moveSpeed = 10;
   


    void Start()
    {
        Debug.Log("Initialized: (" + this.name + ")");
        Cursor.lockState = CursorLockMode.Locked;
        
    }


    void Update()
    {
        /*float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);*/

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * z - transform.forward * x;
        transform.Translate(move * moveSpeed * Time.deltaTime);

    }




}