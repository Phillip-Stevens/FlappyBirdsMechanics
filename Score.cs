using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;

	static Score instance;

	ZubatMovement zubat;

	static public void AddPoint()
	{
		if(instance.zubat.dead)
		{
			return;
		}

		score++;

		if(score > highScore)
		{
			highScore = score;
		}
	}

	void Start()
	{
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		if(player_go == null)
		{
			Debug.LogError("error");
		}

		zubat = player_go.GetComponent<ZubatMovement>();

		score = 0;
		highScore = PlayerPrefs.GetInt ("highScore", 0);
	}

	// Update is called once per frame
	void Update () {

		GetComponent<GUIText>().text = "Score: " + score + "\nHigh Score: " + highScore;	
	}

	void OnDestroy()
	{
		PlayerPrefs.SetInt ("highScore", highScore);
	}
}
