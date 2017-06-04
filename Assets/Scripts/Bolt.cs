using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bolt: MonoBehaviour {
    AssemblyLine line; 

    public void Start() {
        line = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
    }

	public void OnTriggerEnter2D(Collider2D hit) {
        line.getRidOf(hit.gameObject);
    }
}
