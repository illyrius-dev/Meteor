﻿using UnityEngine;

public class ShieldController : Powerup
{
	private GameObject shield;
	private Color blue;
	private Color yellow;
	private Color red;
	private float timeSinceStart;
	private int counter;
	private int shieldHealth;

	// Update is called once per frame
	private new void Update()
	{
		UpdateVisibles();
		timeSinceStart = Time.timeSinceLevelLoad - startTime;
		
		if (timeSinceStart > duration || shieldHealth == 0)
			DeactivatePowerup();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Meteorite"))
		{
			Destroy(collision.gameObject);
			
			shieldHealth--;
			
			if (shieldHealth == 2)
				GetComponent<Renderer>().material.color = yellow;
			else if (shieldHealth == 1)
				GetComponent<Renderer>().material.color = red;
		}
	}

	public void WarningOfShield()
	{
		Indicator();
		if (timeSinceStart > duration - 2)
		{
			CancelInvoke();
			counter = 0;
			InvokeRepeating("Indicator", 0, 0.25f);
		}
		
		if (timeSinceStart > duration)
			CancelInvoke();
	}

	public void Indicator()
	{
		if (counter == 0)
		{
			if (timeSinceStart > 8 && shieldHealth == 1 || timeSinceStart > 8 && shieldHealth == 3)
			{
				if (Debug.isDebugBuild)
					Debug.Log("Red " + timeSinceStart);
				
				GetComponent<Renderer>().material.color = red;
			}
			else if (shieldHealth >= 2)
			{
				if (Debug.isDebugBuild)
					Debug.Log("Yellow " + timeSinceStart);
				
				GetComponent<Renderer>().material.color = yellow;
			}
			
			counter++;
		}
		else if (counter == 1)
		{
			if (shieldHealth == 3)
			{
				if (Debug.isDebugBuild)
					Debug.Log("Blue " + timeSinceStart);
				
				GetComponent<Renderer>().material.color = blue;
			}
			else if (shieldHealth == 2)
			{
				if (Debug.isDebugBuild)
					Debug.Log("Red " + timeSinceStart);
				
				GetComponent<Renderer>().material.color = red;
			}
			
			counter--;
		}
	}

	protected override void ActivatePowerup()
	{
		transform.position = new Vector2(0.0f, -5.13f);

		startTime = Time.timeSinceLevelLoad;
		timeSinceStart = 0;
		counter = 0;
		shieldHealth = 3;

		blue = new Color(0.0f, 0.95f, 1.0f);
		yellow = new Color(1.0f, 1.0f, 0);
		red = new Color(1.0f, 0.2f, 0.2f);
		
		GetComponent<Renderer>().material.color = blue;

		InvokeRepeating("WarningOfShield", duration - 5, 0.5f);
	}

	protected override void DeactivatePowerup()
	{
		DeactivateSlider();
		Destroy(gameObject);
	}
}