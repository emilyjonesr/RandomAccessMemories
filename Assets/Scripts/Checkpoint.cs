using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Sprite gem;
    public Sprite colorGem;
    private SpriteRenderer checkpointSprite;
    public bool checkpointAchieved;
    // Start is called before the first frame update
    void Start()
    {
        checkpointSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D x)
    {
        if (x.tag == "Player")
        {
            checkpointSprite.sprite = colorGem;
            checkpointAchieved = true;

        }
    }
}
