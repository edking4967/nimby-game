using UnityEngine;
//using Application;
using System.Collections;

public class Platform : MonoBehaviour {
    GameObject barrel;	
    Vector2 barrelPos;
    public void Start() {
        barrel = GameObject.Find("barrel");
        barrelPos = barrel.transform.position;
    }
	public void OnCollisionEnter2D(Collision2D c)
	{
        Debug.Log("respawn barrel");
	}
}
