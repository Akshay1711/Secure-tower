using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeed : MonoBehaviour
{
    int speed = 1;
    bool isNormal = true;
    bool isSpeed = false;
    bool isSlow = false;
    public Text theText;
    public Image G;
    public void Speed()
    {
        if (isNormal == false)
        {
         Time.timeScale = 1.5f;
            isSpeed = false;
            isNormal = true;
           G.color = Color.red;

        }

        else if (isSpeed == false)
        {
            Time.timeScale = 1f;
            isNormal = false;
            isSpeed = true;
            G.color = Color.black;


        }

    }
  /*  void Slow()
    {
        if (isNormal == false && isSpeed == false)
        {
            Time.timeScale = speed - 0.5f;
            isNormal = true;
            isSpeed = false;
        }
    }*/
}
