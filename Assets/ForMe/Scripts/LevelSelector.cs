using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

	public SceneFader fader;

	public Button[] levelButtons;

	void Start ()
	{
		int levelReached = MainMenu.inst.levelsUnlocked;
		print("Level reached" + levelReached);

		for (int i = 0; i < levelButtons.Length; i++)
		{
			if (i > levelReached)
				levelButtons[i].interactable = false;
           


        }
    }

	public void Select (string levelName)
	{
		fader.FadeTo(levelName);
	}

    //Delete All Players Prefrences
    public void ResetLevels()
    {
        PlayerPrefs.DeleteAll();
    }
}
