using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [Header("ÉÅÉCÉìUI")]
    public GameObject mainImage;
    public GameObject canvas;
    public GameObject restarButton;
    public Sprite restartSpr;
    public GameObject quitButton;
    public Sprite quitSpr;

    public GameObject timeBar;
    public GameObject tiemText;
    TimeController timeController;

    GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
