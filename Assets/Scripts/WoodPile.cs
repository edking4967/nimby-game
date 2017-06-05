using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WoodPile: MonoBehaviour {
    public GameObject[] woods;
    public Houses houses;
    int woodPointer = 0;
    int clearPointer = 0;
    float clearInterval = .1f;
    bool clearWood = true;
    float timeSave;

    public void Start() {
        woods = new GameObject[] {
            GameObject.Find("wood1"),
            GameObject.Find("wood2"),
            GameObject.Find("wood3"),
            GameObject.Find("wood4"),
            GameObject.Find("wood5")
        };
        houses = GameObject.Find("houses").GetComponent<Houses>();
    }

    public void addWood() {
        woods[woodPointer].GetComponent<SpriteRenderer>().enabled = true; 
        woodPointer++;
        if (woodPointer == woods.Length) {
            clearWood = true;
            timeSave = Time.time;
            clearPointer = woods.Length - 1;
            houses.buildHouse();
            woodPointer = 0;
        }
    }
    public void removeWood() {
        if (woodPointer > 0) {
            woodPointer--;
            woods[woodPointer].GetComponent<SpriteRenderer>().enabled = false; 
        }
    }

    public void Update() {
        if (clearWood) {
            if (Time.time - timeSave >= clearInterval) {
                woods[clearPointer].GetComponent<SpriteRenderer>().enabled = false;
                clearPointer--;
                timeSave = Time.time;
                if (clearPointer == -1) {
                    clearWood = false;
                }
            }
        }
    }

}
