using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Man: MonoBehaviour {
    public GameObject wood;
    Vector2 woodPos;
    public Transform woodPile;

    public void Start() {
        wood = transform.Find("wood").gameObject;
        woodPos = wood.transform.position;
        woodPile = GameObject.Find("woodPile").transform;
    }

    public void dropWood() {
        Debug.Log("drop wood");
        wood.GetComponent<Wood>().goInPile();

    }

    public void restoreWood() {
        //wood.GetComponent<Rigidbody2D>().isKinematic = true;
        //wood.gameObject.GetComponent<SpriteRenderer>().enabled = true;

        //wood.transform.parent = transform;
        //wood.transform.position = woodPos;
    }
}
