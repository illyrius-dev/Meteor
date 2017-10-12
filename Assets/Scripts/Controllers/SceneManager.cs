﻿using System;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
	private float time;

	private void Start()
	{
		//do sound
		Debug.Log("");
	}

	public void PlayButtonPressed()
	{
		LoadScene("Game");
	}

	public void HighscoreButtonPressed()
	{
		LoadScene("Highscores");
	}

	public void SettingsButtonPressed()
	{
		LoadScene("Settings");
	}
	
	public void QuitButtonPressed()
	{
		Application.Quit();
	}

	private void LoadScene(String sceneName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
}