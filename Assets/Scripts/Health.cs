using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentH = 0;
    public int max = 100;

    public HealthBar healthBar;

    void Start() 
    {
        currentH = max; 
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.L ) )
        {
            DamagePlayer(20);
        }
    }

    public void DamagePlayer( int damage )
    {
        currentH -= damage;

        healthBar.SetHealth( currentH );
    }
}
