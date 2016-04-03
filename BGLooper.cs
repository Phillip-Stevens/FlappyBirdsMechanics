using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

    // This is where you state how many tiles you have in the scene that you wish to loop (used to calculate where the next one will go)
	int numBGPanels = 6;

	static float pipeMax = 0.5640425f;
	static float pipeMin = -0.250000f;

	// Use this for initialization
	void Start () {
		GameObject[] Pipes = GameObject.FindGameObjectsWithTag("Pipe");

        // Randomizes the pipes in the scene initially to create a random start each time
		foreach(GameObject Pipe in Pipes)
		{
			Vector3 pos = Pipe.transform.position;

			pos.y = Random.Range(pipeMin, pipeMax);

			Pipe.transform.position = pos;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Used to check if a trigger has happened
	void OnTriggerEnter2D(Collider2D col)
	{
        // Output it in the Unity console to see what we collide with
		Debug.Log ("Triggered: " + col.name);

        // Get the width of the object by using the box collider size
		float widthOfBGObject = ((BoxCollider2D)col).size.x;

        // Store the current position of the collided object
		Vector3 pos = col.transform.position;

        // Add onto its current position what the width * the number of panels we have to calculate the position
		pos.x += widthOfBGObject * numBGPanels;

        // Set it equal to the new position
		col.transform.position = pos;

        // If it hits a pipe randomly generate its range again.
		if(col.tag == "Pipe")
		{
			pos.y = Random.Range(pipeMin, pipeMax);
		}
	}
}

//- widthOfBGObject / 2
