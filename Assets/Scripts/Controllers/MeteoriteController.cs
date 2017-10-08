﻿using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
	private GameObject difficultyManager;
	private DifficultyManagerController difficultyManagerController;
	private Rigidbody2D rb;

	public float minGravityScale;
	public float maxGravityScale;
	public PhysicsMaterial2D lowBounce;


	// FOR SPRITES
	public SpriteRenderer spriteRenderer;
	public Variations[] spriteArray;
	private int spriteIndex;
	[System.Serializable]
	public class Variations {
		public Sprite[] sprites = new Sprite[2];
	}
	


	[HideInInspector]
	public bool touching; // State in which meteorite is in process of flick
	private bool touched; // State in which meteorite HAS BEEN touched
	private GameObject touchObject;

	

	// Use this for initialization
	private void Start()
	{
		touchObject = null;
		touched = false;
		touching = false;
		SelectRandomSprite();
		difficultyManager = GameObject.Find("DifficultyManager");
		
		if (difficultyManager != null)
		{
			difficultyManagerController = difficultyManager.GetComponent<DifficultyManagerController>();
		}

		//InitializeSpeed();
	}

	// Update is called once per frame
	void Update()
	{
		if (touching)
		{
			if (touchObject == null)
			{
				touched = true;
				touching = false;
			}
		}
	}


	public void BlowUp()
	{
		Destroy(gameObject);
	}


	/**
	 * This function is now obselete as the spawn speed is now calculated by the force added on spawn
	 */
	private void InitializeSpeed()
	{
		rb = GetComponent<Rigidbody2D>();
		
		if (difficultyManagerController != null)
		{
			// Initial Gravity Scale
			maxGravityScale = difficultyManagerController.GetMeteoriteSpeedMultiplier();
		}

		float gravityScale = Random.Range(minGravityScale, maxGravityScale);
		rb.gravityScale = gravityScale;
	}

	public void SetTouched(GameObject touchObject)
	{
		this.touchObject = touchObject;
		touching = true;
		
		CircleCollider2D cd = GetComponent<CircleCollider2D>();
		cd.sharedMaterial = lowBounce;

		spriteRenderer.sprite = spriteArray[spriteIndex].sprites[1];
	}

	public bool IsTouching()
	{
		return touching;
	}

	public bool Touched()
	{
		return touched;
	}

	public void SetTouched(bool touched)
	{
		this.touched = touched;
	}

	private void SelectRandomSprite() {
		int size = spriteArray.Length;
		spriteIndex = Random.Range(0, size);
		spriteRenderer.sprite = spriteArray[spriteIndex].sprites[0];
	}

	
}

