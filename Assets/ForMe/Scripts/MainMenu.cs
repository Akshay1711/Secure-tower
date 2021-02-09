using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "MainLevel";
    public bool isMuted;
    public int levelsUnlocked = 0;
	public SceneFader sceneFader;
    public static MainMenu inst;
    public GameObject toggleAudio;

    private void Start()
    {
        inst = this;
        bool isLogged = LoadPlayerData();
        if(!isLogged)
            isMuted = false;
        if(isMuted && toggleAudio != null)
        {
            Debug.Log("The audio is muted");
            toggleAudio.GetComponent<Toggle>().isOn = true;
        }
        if (!isMuted && toggleAudio != null)
        {
            Debug.Log("The audio is un-muted");
            toggleAudio.GetComponent<Toggle>().isOn = false;
        }

    }
    public void Play ()
	{
		sceneFader.FadeTo(levelToLoad);
	}

	public void Quit ()
	{
		Debug.Log("Exiting...");
        Application.Quit();
	}

    public void MutePressed()
    {
        isMuted = !isMuted;
        SavePlayerData();
        AudioListener.pause = isMuted;
    }
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeToOptions()
    {
        SceneManager.LoadScene(5);

    }

    public void ResetLevels()
    {
        levelsUnlocked = 0;
        SavePlayerData();
    }

    public void SavePlayerData()
    {
        SaveGameData.SavePlayerData(this);

    }

    public bool LoadPlayerData()
    {
        GameLog log = SaveGameData.LoadPlayerDetails();
        if(log != null)
        {
            isMuted = log.muteStats;
            levelsUnlocked = log.levelsUnlocked;
            return true;
        }
        else{
            return false;
        }

    }
}
