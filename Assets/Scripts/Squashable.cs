using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Squashable: MonoBehaviour {
    public Sprite squashed;
    public Sprite spriteSave;

    public void Start() {
        spriteSave = GetComponent<SpriteRenderer>().sprite;
    }

    public void squash() {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = squashed;
    }
    public void unsquash() {
        GetComponent<Animator>().enabled = true ;
        GetComponent<SpriteRenderer>().sprite = spriteSave;
    }
}
