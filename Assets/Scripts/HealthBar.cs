using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Health player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = player.max;
        healthBar.value = player.max;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}

