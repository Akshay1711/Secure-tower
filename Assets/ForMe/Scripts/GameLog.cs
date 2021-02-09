using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameLog
{
    public bool muteStats;
    public int levelsUnlocked;

    public GameLog (MainMenu menu)
    {
        muteStats = menu.isMuted;
        levelsUnlocked = menu.levelsUnlocked;
    }
}
