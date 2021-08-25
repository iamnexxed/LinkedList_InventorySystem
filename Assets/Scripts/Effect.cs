
using UnityEngine;

public class Effect : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyEffect", 1f);
    }

    void DestroyEffect()
    {
        Destroy(gameObject);
    }

}
