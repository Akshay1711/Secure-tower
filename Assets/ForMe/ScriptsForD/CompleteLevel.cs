using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	public string SceneNameOfTheMenu = "MainMenu";

	public string NextLevelName = "Leve2";
	public int levelToUnlock = 2;

	public SceneFader sceneFader;

	public void Continue ()
	{
		sceneFader.FadeTo(NextLevelName);
	}

	public void Menu ()
	{
		sceneFader.FadeTo(SceneNameOfTheMenu);
	}

}
