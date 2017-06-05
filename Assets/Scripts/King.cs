using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class King: MonoBehaviour {

    float moveSpeed = 2f;
    GameObject barrel;

    public void Start() {
        barrel = GameObject.Find("barrel");
        barrel.GetComponent<Animator>().StartPlayback();
    }

	void FixedUpdate () {


        if(Input.GetKey(KeyCode.LeftArrow))
            move(Vector2.left, Time.deltaTime);
        if(Input.GetKey(KeyCode.RightArrow))
            move(Vector2.right, Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)) {
            barrel.GetComponent<Animator>().StopPlayback();
            barrel.GetComponent<Rigidbody2D>().isKinematic = false;
            transform.DetachChildren();
        }
	}

    void move(Vector2 direction, float time) {
        transform.position += (Vector3) direction * time * moveSpeed;
    }
}
