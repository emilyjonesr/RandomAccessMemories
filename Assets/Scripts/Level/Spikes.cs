using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Rigidbody2D player_;
    public PlayerMovement actualPlayer;
    public Health playerHealth_;
    public Animator animateHealth;
    public HealthBar healthBarDisp;
    [SerializeField] private AudioSource hitSound;


    void Start()
    {
        player_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        playerHealth_ = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        animateHealth.SetFloat("Health", playerHealth_.currentH);
        actualPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            animateHealth.SetBool("isHit", true);
            animateHealth.SetFloat("Health", playerHealth_.currentH - 20.0f);
            playerHealth_.currentH -= 20.0f;
            healthBarDisp.SetHealth(playerHealth_.currentH);
            StartCoroutine(actualPlayer.KnockBack(0.02f, 350, player_.transform.position));
            hitSound.Play();
            animateHealth.SetBool("isHit", false);

        }
    }
   
}
