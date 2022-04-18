using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentH = 0.0f;
    public float max = 100.0f;

    public HealthBar healthBar;

    void Start() 
    {
        currentH = max; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) )
        {
            Destroy(20.0f);
        }
    }

    public void Destroy( float damage )
    {
        currentH -= damage;
        healthBar.SetHealth(currentH);
    }
}
