using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {

	Transform player;

	float offsetX;

	// Use this for initialization
	void Start ()
	{
        // find a game object in the scene with the name player
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");

        // If no player is found then we need to output the error forr clarity
		if(player_go == null)
		{
			Debug.Log("Couldnt find an object with tag Player");
			return;
		}

        // set our transform to the players current transformed position
		player = player_go.transform;

        // Add an offset (unused)
		offsetX = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
	
        // As long as there is a player set the camera position to the position of the player
		if(player != null)
		{
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			transform.position = pos;
		}
	}
}
