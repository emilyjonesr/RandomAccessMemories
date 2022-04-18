using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float delay;
    public PlayerMovement player;
    public Health playerHealth;
    public Animator animatorHealth;
    public HealthBar healthBar_;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource hurtSound;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        animatorHealth.SetFloat("Health", playerHealth.currentH);

    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);

        if (playerHealth.currentH > 1.0f)
        {
            animatorHealth.SetBool("isHit", true);
            animatorHealth.SetFloat("Health", playerHealth.currentH - 20.0f);
            playerHealth.currentH -= 20.0f;
            healthBar_.SetHealth(playerHealth.currentH);
            animatorHealth.SetBool("isHit", false);
            hurtSound.Play();
        }
      
        player.transform.position = player.savePoint;
        player.gameObject.SetActive(true);


    }

    public void Death()
    {
        if (playerHealth.currentH < 1.0f)
        {
            deathSound.Play();
            animatorHealth.SetFloat("Health", 0.0f);
            animatorHealth.SetBool("isDead", true);
            player.savePoint = player.originalPosition;
            player.transform.position = player.savePoint;
            playerHealth.currentH = 100.0f; 
            animatorHealth.SetFloat("Health", 100.0f);
            healthBar_.SetHealth(100.0f);
            animatorHealth.SetBool("isDead", false);
        }

    }
}
