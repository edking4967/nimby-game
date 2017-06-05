using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Houses: MonoBehaviour {
    
    GameObject[] houses;
    int housePointer = 0;
    public void Start() {
        houses = new GameObject[] {
            GameObject.Find("house1-1"),
            GameObject.Find("house1-2"),
            GameObject.Find("house1-3"),
            GameObject.Find("house1-4"),
            GameObject.Find("house1-5"),
        };
    }
    
    public void buildHouse() {
        if(housePointer < houses.Length) {
            houses[housePointer].GetComponent<SpriteRenderer>().enabled = true;
            houses[housePointer].GetComponent<House>().hideSmogs();
            housePointer = housePointer + 1;
        }
    } 
}
