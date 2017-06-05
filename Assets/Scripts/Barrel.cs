using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Barrel: MonoBehaviour {
    AssemblyLine line; 
    King king;
    GameObject kingObj;
    float timeSave;
    float interval = .8f;
    bool onPlatform = false;
    Vector2 initialPos;
    AudioSource soundEffect;

    public void Start() {
        line = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
        kingObj = GameObject.Find("king");
        king = GameObject.Find("king").GetComponent<King>();
        initialPos = transform.position;
        soundEffect = GetComponent<AudioSource>();
    }

	public void OnTriggerEnter2D(Collider2D hit) {
        if (hit.gameObject.tag == "actor") {
            if (!onPlatform) {
                line.getRidOf(hit.gameObject);
                hit.gameObject.GetComponent<Squashable>().squash();
            } 
        }
    }

    public void Update(){
        if (onPlatform && Time.time - timeSave >= interval) { 
            fallOffPlatform();
            timeSave = -1;
        }
        if (Camera.main.WorldToScreenPoint(transform.position).y <= 0) {
            // reset barrel
            initialPos.x = kingObj.transform.position.x;
            transform.position = initialPos;
            GetComponent<Rigidbody2D>().isKinematic = true;
            onPlatform = false;
            GetComponent<BoxCollider2D>().enabled = true;
            transform.parent = kingObj.transform;
            GetComponent<Animator>().Play("barrel-still");
        }
    }

    void fallOffPlatform() {
        Debug.Log("fallOffPlatform");
        GetComponent<Animator>().Play("barrel-fall");
        GetComponent<BoxCollider2D>().enabled =false;
        soundEffect.mute = false;
        soundEffect.Play();
    }

    public void OnCollisionEnter2D(Collision2D hit) {
        timeSave = Time.time;
        onPlatform = true;
        GetComponent<Animator>().Play("barrel-still");
    }
}
