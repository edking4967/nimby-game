using UnityEngine;
using System.Collections;

public class MoveRight: MonoBehaviour {
	
    public Vector3 velocity;
    public void Start() {
        velocity = new Vector3(2f, 0f, 0f);
    }

	public void Update()
	{
        float dt = Time.deltaTime;
        transform.position += dt * velocity;
	}
}
