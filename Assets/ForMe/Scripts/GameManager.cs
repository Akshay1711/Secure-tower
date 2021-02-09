using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
	public GameObject pauseBtn;
	public GameObject ffBtn;

	bool isGameOver= false;


	void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update () {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
		if(pauseBtn !=null)
			pauseBtn.SetActive(!pauseBtn.activeSelf);
		if (ffBtn != null)
			ffBtn.SetActive(!ffBtn.activeSelf);
		isGameOver = true;
	}

	public void WinLevel ()
	{
        if(isGameOver == false)
        {
	        	GameIsOver = true;

	        	completeLevelUI.SetActive(true);
			if (pauseBtn != null)
				pauseBtn.SetActive(!pauseBtn.activeSelf);
			if (ffBtn!= null)
				ffBtn.SetActive(!ffBtn.activeSelf);

		}
	}

}
