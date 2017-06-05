using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Houses: MonoBehaviour {
    
    GameObject[] houses;
    int housePointer = 0;
    AssemblyLine assemblyLine;
    public void Start() {
        assemblyLine = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
        houses = new GameObject[] {
            GameObject.Find("house1-1"),
            GameObject.Find("house1-2"),
            GameObject.Find("house1-3"),
            GameObject.Find("house1-4"),
            GameObject.Find("house2-1"),
            GameObject.Find("house2-2"),
            GameObject.Find("house2-3"),
            GameObject.Find("house2-4")
        };
    }
    
    public void Update() {
        if (assemblyLine.profit % 3 == 1) {
            houses[housePointer].GetComponent<SpriteRenderer>().enabled = true;
            housePointer++;
        }
    } 
}
