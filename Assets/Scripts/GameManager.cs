using UnityEditor;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    public static GameManager instance
    {
        get
        {
            return _instance; // same as "get;"
        }
        set
        {
            _instance = value;
        }
    }

    public Slider healthSlider;

    int _health;

    public int health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }


    void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

    private void Start()
    {
        health = 10;
    }


    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
