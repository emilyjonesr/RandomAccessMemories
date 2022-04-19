using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facts : MonoBehaviour
{
    public GameObject LevelCompletedPanel;
    public GameObject s;
    public GameObject player;
    public float time;
    Vector3 pos;
    public GameObject inventory_scroll;
    bool player_pos = false;
    public bool mouseClick = false;
    Level1.Scroll scroll;
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private AudioSource winSound;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        
        if(s.name == "Scroll1"){
            scroll = new Level1.Scroll("Dinosaurs lived on Earth for more than 150 million years!");
            scroll.name = s.name;
            scroll.inv_name = "Inv1";
        }
        if(s.name == "Scroll2"){
            scroll = new Level1.Scroll("Their time on Earth covered the Triassic, Jurassic,\n and Cretaceous geological periods.");
            scroll.name = s.name;
            scroll.inv_name = "Inv2";
        }
        if(s.name == "Scroll3"){
            scroll = new Level1.Scroll("Approximately 66 million years ago, The Cretaceous Paleogene (K-T)\n extinction event wiped out three quarters of the plant and animal species on Earth!");
            scroll.inv_name = "Inv3";
            scroll.name = s.name;
        }
        if(s.name == "Scroll4"){
            scroll = new Level1.Scroll("The K-T extinction was caused by a comet or asteroid larger\n than Mount Everest colliding with the Earth!");
            scroll.inv_name = "Inv4";
            scroll.name = s.name;
        }
        if(s.name == "Scroll5"){
            scroll = new Level1.Scroll("This asteroid, known as the Chicxulub impactor, left behind\n a crater off the coast of Mexico thought to be over 100 miles wide!");
            scroll.inv_name = "Inv5";
            scroll.name = s.name;
        }
        if(s.name == "Scroll6"){
            scroll = new Level1.Scroll("Although the asteroid killed most dinosaurs, one group\n remains alive today - birds!");
            scroll.inv_name = "Inv6";
            scroll.name = s.name;
        }
        if(s.name == "Scroll7"){
            scroll = new Level1.Scroll("Birds were one of the few species to survive extinction\n because of their ability to survive off of small seeds and produce.");
            scroll.inv_name = "Inv7";
            scroll.name = s.name;
        }
        if(s.name == "Scroll8"){
            scroll = new Level1.Scroll("In modern day, paleontologists (scientists who study fossils)\n learn about dinosaurs through their fossilized remains.");
            scroll.inv_name = "Inv8";
            scroll.name = s.name;
        }
        if(s.name == "Scroll9"){
            scroll = new Level1.Scroll("Paleontologists have classified approximately 700 unique\n species of dinosaurs so far.");
            scroll.inv_name = "Inv9";
            scroll.name = s.name;
        }
        if(s.name == "Scroll10"){
            scroll = new Level1.Scroll("Dinosaurs roamed the entire Earth; their fossils can be\n found on all landmasses we now know as the 7 continents!");
            scroll.inv_name = "Inv10";
            scroll.name = s.name;
        }

        inventory_scroll.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        
        float length = Vector3.Distance(s.transform.position, player.transform.position);
        if(length <= 0.8){
            if (scroll.collected != true) {
                Level1.scrolls.Add(scroll);
                collectSound.Play();
            }
            scroll.collected = true;
        }
        else{
            player_pos = false;
        }

        if(scroll.collected == true && scroll.inventory == false){
            scroll.inventory = true;
            inventory_scroll.SetActive(true);
        }

        if(Input.GetMouseButtonDown(0)){
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit collider;
            if(Physics.Raycast(r, out collider)){
                int num = 0;
                if(scroll.inv_name == collider.transform.name){
                    mouseClick = true;
                    
                }

            }
            else{
                mouseClick = false;
            }
        }

        if(Level1.scrolls.Count == 4) {
            LevelCompletedPanel.SetActive(true);
            winSound.Play();
            Level1.scrolls.Clear();
        }

        
    }

    void OnGUI()
    {
        if(mouseClick){
             GUI.Button(new Rect(150, 60, 520, 150), scroll.fact);
        }
       
                
    }
}