using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToNextLevelButton : MonoBehaviour
{
    private int currentLevel;
    public int nextSceneLoad;
    public int LatestLevelIndex = 3;
    void Start()
    {
    }
    public void RestartLevelClick()
    {
        SceneManager.LoadScene(currentLevel);
    }
    public void ONclickButton()
    {

        if (SceneManager.GetActiveScene().buildIndex == LatestLevelIndex)
        {
            Debug.Log("You Completed ALL Levels");

            //Show Win Screen or Somethin.
        }
        else
        {
            int currSceneIndex = SceneManager.GetActiveScene().buildIndex - 2;
            if (MainMenu.inst.levelsUnlocked < 4 && currSceneIndex == MainMenu.inst.levelsUnlocked)
            {
                MainMenu.inst.levelsUnlocked += 1;
                Debug.Log("Level Unlocked: " + MainMenu.inst.levelsUnlocked);
                MainMenu.inst.SavePlayerData();
            }

            //Move to next level
            SceneManager.LoadScene(nextSceneLoad);
            Time.timeScale = 1f;
           
        }
    }
}
