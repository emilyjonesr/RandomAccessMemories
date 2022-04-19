using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Sprite gem;
    public Sprite colorGem;
    private SpriteRenderer checkpointSprite;
    public bool checkpointAchieved;
    [SerializeField] private AudioSource checkpointSound;
    //Health Variables
    public Health healthOfPlayer;
    public Animator animationHealthCount;
    public HealthBar bar;

    // Start is called before the first frame update
    void Start()
    {
        checkpointSprite = GetComponent<SpriteRenderer>();
        healthOfPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        animationHealthCount.SetFloat("Health", healthOfPlayer.currentH);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D x)
    {
        if (x.tag == "Player")
        {
             if (checkpointAchieved == false)
            {
                checkpointSound.Play();
                animationHealthCount.SetFloat("Health", 100.0f);
                healthOfPlayer.currentH = 100.0f;
                bar.SetHealth(healthOfPlayer.currentH);
            }
            checkpointSprite.sprite = colorGem;
            checkpointAchieved = true;
        }
    }
}
