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
    bool mouseClick = false;
    List<Scrolls> total = new List<Scrolls>();


    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        
       if(s.name == "Scroll1"){
            scroll = new Scrolls("Dinosaurs lived on Earth for 245 years!");
            scroll.name = s.name;
            scroll.inv_name = "Inv1";
            Debug.Log(scroll.name);
            
        }
        if(s.name == "Scroll2"){
            scroll = new Scrolls("Paleontologists study dinosaurs through the examination of fossils!");
            scroll.name = s.name;
            scroll.inv_name = "Inv2";
            Debug.Log(scroll.name);
        }
         if(s.name == "Scroll3"){
            scroll = new Scrolls("The T-Rex lived during the Cretacious Period!");
            scroll.inv_name = "Inv3";
            scroll.name = s.name;
        }
        if(s.name == "Scroll4"){
            scroll = new Scrolls("Modern birds have a skeletal structure similar to dinosaurs!");
            scroll.inv_name = "Inv4";
            scroll.name = s.name;
        }
        if(s.name == "Scroll5"){
            scroll = new Scrolls("The extinction of dinosaurs was about 66 million years ago!");
            scroll.inv_name = "Inv5";
            scroll.name = s.name;
        }
        if(s.name == "Scroll6"){
            scroll = new Scrolls("Barnum Brown is a well known dinosaur hunter who discovered the first T Rex!");
            scroll.inv_name = "Inv6";
            scroll.name = s.name;
        }
        if(s.name == "Scroll7"){
            scroll = new Scrolls("The Triassic Period had the earliest dinosaurs!");
            scroll.inv_name = "Inv7";
            scroll.name = s.name;
        }
        if(s.name == "Scroll8"){
            scroll = new Scrolls("There are about 700 species of dinosaurs!");
            scroll.inv_name = "Inv8";
            scroll.name = s.name;
        }
        if(s.name == "Scroll9"){
            scroll = new Scrolls("Dinosaurs are found on 7 continents!");
            scroll.inv_name = "Inv9";
            scroll.name = s.name;
        }
        if(s.name == "Scroll10"){
            scroll = new Scrolls("A fossilized bone is made up of minerals mostly!");
            scroll.inv_name = "Inv10";
            scroll.name = s.name;
        }

        inventory_scroll.SetActive(false);

         
    }

    // Update is called once per frame
    void Update()
    {
        
        float length = Vector3.Distance(s.transform.position, player.transform.position);
        if(length <= 0.5){
           //player_pos = true;
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

                //have to figure out when you click scroll again, gui button should dissapear
            }
        }

        

        
    }

    void OnGUI()
    {
        if(mouseClick){
             GUI.Button(new Rect(300, 100, 400, 200), scroll.fact);
            
             
             
        }
       
                
    }
}

