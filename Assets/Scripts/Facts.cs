using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facts : MonoBehaviour
{

    
    public class Scrolls{
        public string fact;
        public string name;

        public Scrolls(string sentence){
            fact = sentence;

        }
    }

    public GameObject s;
    public Scrolls scroll;
    public GameObject player;
    bool player_pos = false;


    // Start is called before the first frame update
    void Start()
    {
        
       if(s.name == "Scroll1"){
            scroll = new Scrolls("Dinosaurs lived on Earth for 245 years!");
            scroll.name = s.name;
            Debug.Log(scroll.name);
            
        }
        if(s.name == "Scroll2"){
            scroll = new Scrolls("Paleontologists study dinosaurs through the examination of fossils!");
            scroll.name = s.name;
            Debug.Log(scroll.name);
        }
         if(s.name == "Scroll3"){
            scroll = new Scrolls("The T-Rex lived during the Cretacious Period!");
            scroll.name = s.name;
        }
        if(s.name == "Scroll4"){
            scroll = new Scrolls("Modern birds have a skeletal structure similar to dinosaurs!");
            scroll.name = s.name;
        }
        if(s.name == "Scroll5"){
            scroll = new Scrolls("The extinction of dinosaurs was about 66 million years ago!");
            scroll.name = s.name;
        }
        if(s.name == "Scroll6"){
            scroll = new Scrolls("Barnum Brown is a well known dinosaur hunter who discovered the first T Rex!");
            scroll.name = s.name;
        }
        if(s.name == "Scroll7"){
            scroll = new Scrolls("The Triassic Period had the earliest dinosaurs!");
            scroll.name = s.name;
        }
        if(s.name == "Scroll8"){
            scroll = new Scrolls("There are about 700 species of dinosaurs!");
            scroll.name = s.name;
        }
        if(s.name == "Scroll9"){
            scroll = new Scrolls("Dinosaurs are found on 7 continents!");
            scroll.name = s.name;
        }
        if(s.name == "Scroll10"){
            scroll = new Scrolls("A fossilized bone is made up of minerals mostly!");
            scroll.name = s.name;
        }

         
    }

    // Update is called once per frame
    void Update()
    {
        

        float length = Vector3.Distance(s.transform.position, player.transform.position);
        if(length <= 0.5){
           player_pos = true;
        }
        else{
            player_pos = false;
        }
    }

    void OnGUI()
    {
        if(player_pos == true){
             GUI.Button(new Rect(s.transform.position.x, s.transform.position.y, 400, 200), scroll.fact);
        }
       
                
    }
}
