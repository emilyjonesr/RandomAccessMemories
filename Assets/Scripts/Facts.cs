using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facts : MonoBehaviour
{

    
    public class Scrolls{
        public string fact;
        public string name;
        public bool collected;
        public bool inventory;
        public string inv_name;
        public Scrolls(string sentence){
            fact = sentence;
            collected = false;
            inv_name = "";
            inventory = false;

        }
    }

    public GameObject s;
    public Scrolls scroll;
    public GameObject player;
    public float time;
    Vector3 pos;
    public GameObject inventory_scroll;
    bool player_pos = false;
    public bool mouseClick = false;
    List<Scrolls> total = new List<Scrolls>();


    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        
       if(s.name == "Scroll1"){
            scroll = new Scrolls("Dinosaurs lived on Earth for more than 150 million years!");
            scroll.name = s.name;
            scroll.inv_name = "Inv1";
            Debug.Log(scroll.name);
            
        }
        if(s.name == "Scroll2"){
            scroll = new Scrolls("Their time on Earth covered the Triassic, Jurassic, and Cretaceous geological periods.");
            scroll.name = s.name;
            scroll.inv_name = "Inv2";
            Debug.Log(scroll.name);
        }
         if(s.name == "Scroll3"){
            scroll = new Scrolls("Approximately 66 million years ago, The Cretaceous Paleogene (K-T) extinction event wiped out three quarters of the plant and animal species on Earth!");
            scroll.inv_name = "Inv3";
            scroll.name = s.name;
        }
        if(s.name == "Scroll4"){
            scroll = new Scrolls("The K-T extinction was caused by a comet or asteroid larger than Mount Everest colliding with the Earth!");
            scroll.inv_name = "Inv4";
            scroll.name = s.name;
        }
        if(s.name == "Scroll5"){
            scroll = new Scrolls("This asteroid, known as the Chicxulub impactor, left behind a crater off the coast of Mexico thought to be over 100 miles wide!");
            scroll.inv_name = "Inv5";
            scroll.name = s.name;
        }
        if(s.name == "Scroll6"){
            scroll = new Scrolls("Although the asteroid killed most dinosaurs, one group remains alive today - birds!");
            scroll.inv_name = "Inv6";
            scroll.name = s.name;
        }
        if(s.name == "Scroll7"){
            scroll = new Scrolls("Birds were one of the few species to survive extinction because of their ability to survive off of small seeds and produce.");
            scroll.inv_name = "Inv7";
            scroll.name = s.name;
        }
        if(s.name == "Scroll8"){
            scroll = new Scrolls("In modern day, paleontologists (scientists who study fossils) learn about dinosaurs through their fossilized remains.");
            scroll.inv_name = "Inv8";
            scroll.name = s.name;
        }
        if(s.name == "Scroll9"){
            scroll = new Scrolls("Paleontologists have classified approximately 700 unique species of dinosaurs so far.");
            scroll.inv_name = "Inv9";
            scroll.name = s.name;
        }
        if(s.name == "Scroll10"){
            scroll = new Scrolls("Dinosaurs roamed the entire Earth; their fossils can be found on all landmasses we now know as the 7 continents!");
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
           scroll.collected = true;
           total.Add(scroll);
        
        }
        else{
            player_pos = false;
        }

        for(int i = 0; i < total.Count; i++){
            if(total[i].inventory == false){
                total[i].inventory = true;
                inventory_scroll.SetActive(true);
                break;
            }
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

        
    }

    void OnGUI()
    {
        if(mouseClick){
             GUI.Button(new Rect(300, 100, 600, 200), scroll.fact);
            
        }
       
                
    }
}

