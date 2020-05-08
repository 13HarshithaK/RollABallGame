using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControls : MonoBehaviour {
	private Rigidbody rb;
	public float speed=10f;
	private int score=0;
	public Text ScoreText;
	bool GameOver=false;
	private int pickupAmount;
	public Text GameOverText;
	private int strike=0;
	public Text StrikesText;
	public Text StrikeOutText;
	void Start(){
		rb = GetComponent<Rigidbody> ();	

	}

	void Update () {
		
	}


	void FixedUpdate()
	{
		float moveh = Input.GetAxis ("Horizontal");
		float movev = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3(moveh,0.0f,movev);
		rb.AddForce(movement*speed);
	}

	public void butt_rt()
	{
		float moveh = 5.0f;
		Vector3 movement = new Vector3(moveh,0.0f,0.0f);
		rb.AddForce(movement*speed);
	}


	public void butt_lt()
	{
		float moveh = -5.0f;
		Vector3 movement = new Vector3(moveh,0.0f,0.0f);
		rb.AddForce(movement*speed);
	}

	public void butt_dw()
	{
		float movev = -5.0f;
		Vector3 movement = new Vector3(0.0f,0.0f,movev);
		rb.AddForce(movement*speed);
	}

	public void butt_up()
	{
		float movev = 5.0f;
		Vector3 movement = new Vector3(0.0f,0.0f,movev);
		rb.AddForce(movement*speed);
	}

	void OnTriggerEnter(Collider Other)
	{
		
		if (GameOver == false) 
		{
			if (Other.gameObject.CompareTag ("PickUp")) {
				Other.gameObject.SetActive (false);
				score++;
				ScoreText.text = "Score: " + score;
			}
			check ();
		}
	
	}

	void OnCollisionEnter(Collision obj)
	{
		if (GameOver == false) 
		{
			if (obj.gameObject.CompareTag ("Walls")) {
				strike++;
				StrikesText.text = "Strikes: " + strike;
			}
			check ();
		}

	}

	void check()
	{
		if (score == 12)
		{	
			GameOver = true;
			GameOverText.gameObject.SetActive (true);
		}

		if (strike == 5)
		{
			GameOver = true;
			StrikeOutText.gameObject.SetActive (true);
		}
	}

}
