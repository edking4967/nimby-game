using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Man: MonoBehaviour {
    public GameObject wood;
    Vector2 woodPos;


    public void Start() {
        wood = transform.Find("wood").gameObject;
    }

    public void dropWood() {
        Debug.Log(name + " dropped wood");
        wood.gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }

    public void grabWood() {
        Debug.Log(name + " grabbed wood");
        wood.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
