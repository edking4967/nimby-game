using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barrel: MonoBehaviour {
    AssemblyLine line; 
    King king;
    float timeSave;
    float interval = .8f;
    bool onPlatform = false;

    public void Start() {
        line = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
        king = GameObject.Find("king").GetComponent<King>();
    }

	public void OnTriggerEnter2D(Collider2D hit) {
        if (!onPlatform) {
            line.getRidOf(hit.gameObject);
            hit.gameObject.GetComponent<Squashable>().squash();
        } 
    }

    public void Update(){
        if (onPlatform && Time.time - timeSave >= interval) { 
            fall();
            timeSave = -1;
        }
    }

    void fall() {
        GetComponent<Animator>().enabled = false;
        GetComponent<BoxCollider2D>().enabled =false;
    }

    public void OnCollisionEnter2D(Collision2D hit) {
        timeSave = Time.time;
        onPlatform = true;
        GetComponent<Animator>().enabled = true;
    }
}
