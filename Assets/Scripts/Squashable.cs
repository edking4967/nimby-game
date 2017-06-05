using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Squashable: MonoBehaviour {
    public Sprite squashed;
    public Sprite spriteSave;
    public bool isSquashed;

    public void Start() {
        spriteSave = GetComponent<SpriteRenderer>().sprite;
        isSquashed = false; 
    }

    public void squash() {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = squashed;
        isSquashed = true; 
    }
    public void unsquash() {
        GetComponent<Animator>().enabled = true ;
        GetComponent<SpriteRenderer>().sprite = spriteSave;
        //isSquashed = false; 
    }
}
