using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Squashable: MonoBehaviour {
    public Sprite squashed;

    public void squash() {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = squashed;
    }
}
