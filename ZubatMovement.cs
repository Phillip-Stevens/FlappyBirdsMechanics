using UnityEngine;
using System.Collections;

public class ZubatMovement : MonoBehaviour {

    // Spawn chance for shiny zubat instead of normal zubat (1 in 8192 [testing purposes will be 1 in 2])
    // Change it so instead of zubat being on screen it spawns in and decides which prefab to use
    // Menu system
    // Upgrade score notifications
    // Comment EVERYTHING to send off as a part of my Portfolio

	// velocity and gravity vector3's
	float flapSpeed = 100f;

	float deathCooldown;

	//movement
	float forwardSpeed = 1f;

	bool didFlap = false;
	public bool dead = false;

	Animator animator;

	// Use this for initialization
	void Start ()
	{
		animator = transform.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if(dead)
		{
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0)
			{
                // Mousebutton 0 translates to tapping on a screen so you can kill two birds with one stone!
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
				{
                    // This works but you should look into using the scene manager (new feature)
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
		else
		{
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				didFlap = true;
				Debug.Log("FLAPPING");
			}
		}
	}
	
	// Physics upates OP
	void FixedUpdate ()
	{
		if(dead)
		{
			return;
		}
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);

		if(didFlap)
		{
			animator.SetTrigger("DoFlap");
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
			didFlap = false;
		}

		if(GetComponent<Rigidbody2D>().velocity.y > 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			float angle = Mathf.Lerp (0, -90, -GetComponent<Rigidbody2D>().velocity.y / 2f);
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;
	}
}
