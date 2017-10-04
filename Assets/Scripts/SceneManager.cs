﻿using System;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
	private float time;
	
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
		time = Time.timeSinceLevelLoad + 0.5f;

		while (Time.timeSinceLevelLoad <= time)
		{
			
		}
		
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
}