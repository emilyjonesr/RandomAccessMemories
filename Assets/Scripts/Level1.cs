using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public class Scroll{
        public string fact;
        public string name;
        public bool collected;
        public bool inventory;
        public string inv_name;
        public Scroll(string sentence){
            fact = sentence;
            collected = false;
            inv_name = "";
            inventory = false;

        }
    }

    public static List<Scroll> scrolls = new List<Scroll>();
}
