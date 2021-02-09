using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManaging : MonoBehaviour
{
    private int sceneToContinue;
    //Getting Index from ScceneManger To change Scenes
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    //quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Delete All Players Prefrences
    public void ResetLevels()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("levelAt");
        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
            Time.timeScale = 1f;
        }
        else
            return;

    }
}
