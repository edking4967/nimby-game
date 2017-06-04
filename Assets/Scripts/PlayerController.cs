using UnityEngine;
using System.Collections;
//using Application;

public class PlayerController : MonoBehaviour {
	public bool isJumping = true;	
	public GameObject monk;
	Animator anim;
	Rigidbody2D rb;
	public int health = 10;
	GameObject proj;
	Vector2 projVel;
	//Door currentDoor;
	public GravitySprite gs;

	public void Start()
	{
		monk = GameObject.Find ("Monk");
		anim = monk.GetComponent<Animator> ();
		rb = monk.GetComponent<Rigidbody2D> ();
		gs = GetComponent<GravitySprite> ();

		// Monk is not currently charging aura:
		anim.SetBool ("Charging", false);

		// Monk is not currently touching a door:
		//currentDoor = null;
	}

	/*
	public void Update()
	{
		checkOffscreen ();

	}
	*/
		
	public void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "enemyProjectile") {
			this.health--;
			Destroy (c.gameObject);
		}
	}

    /*
	public void OnTriggerEnter2D(Collider2D c)
	{
		Debug.Log ("monk triggerenter");
		if (c.gameObject.tag == "Door") {
			currentDoor = c.gameObject.GetComponent<Door> ();
		}
	}


	public void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Door")
			currentDoor = null;
	}
    */

	public void fireProjectile()
	{
		proj = (GameObject)Instantiate(Resources.Load("Prefabs/projectile")); 
		proj.transform.position = monk.transform.position;
		projVel = new Vector2 (.1f,0);

		if (!gs.isFacingRight)
			projVel = -projVel;

		proj.GetComponent<Rigidbody2D> ().AddForce (projVel);
	}

	public void chargeAura(bool state)
	{
		anim.SetBool ("Charging", state);
	}

    /*
	// The player has tried to open a door. Check if there is a door and if so, open it.
	public void checkDoor()
	{
		if (currentDoor) {
			currentDoor.enterRoom();
		}
	}
    */

    public void climbVine()
    {
        gs.climbVine();
    }

	public void checkOffscreen()
	{
		if (!monk.GetComponent<Renderer> ().isVisible ) {
			Debug.Log ("monk offcreen");
		}
	}
}
