using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wood: MonoBehaviour {
    public Transform woodPile;

    public void Start() {
        woodPile = GameObject.Find("woodPile").transform;
    }

    public void goInPile() {
        Vector2 pos = new Vector2(woodPile.transform.position.x, transform.position.y);
        transform.position = pos;
        transform.parent.DetachChildren();
        transform.parent = woodPile;
    }

}
