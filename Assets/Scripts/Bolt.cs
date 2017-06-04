using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bolt: MonoBehaviour {
    AssemblyLine line; 
    King king;

    public void Start() {
        line = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
        king = GameObject.Find("king").GetComponent<King>();
        GetComponent<SpriteRenderer>().enabled = true;
    }

	public void OnTriggerEnter2D(Collider2D hit) {
        line.getRidOf(hit.gameObject);
        king.boltDir = Vector2.zero;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
