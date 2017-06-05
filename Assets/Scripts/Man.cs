using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Man: MonoBehaviour {
    GameObject wood;
    Vector2 woodPos;

    public void Start() {
        wood = transform.Find("wood").gameObject;
        woodPos = wood.transform.position;
    }

    public void dropWood() {
        Debug.Log("drop wood");
        wood.GetComponent<Rigidbody2D>().isKinematic = false;
        transform.DetachChildren();
        wood.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

    }

    public void restoreWood() {
        wood.GetComponent<Rigidbody2D>().isKinematic = true;
        wood.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        wood.transform.position = woodPos;
    }
}
