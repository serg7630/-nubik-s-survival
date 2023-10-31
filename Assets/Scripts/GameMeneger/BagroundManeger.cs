using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagroundManeger : MonoBehaviour
{
  public static  BagroundManeger S;
    public bool GamePause = false;
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            //Time.timeScale = 0;
            //GameMeneger.S.SoundPause();
        }
        else
        {
            //Time.timeScale = 1;
            //GameMeneger.S.SoundPlay();
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (GamePause == true)
            {
                return;
            }
            //Time.timeScale = 1;
            Debug.Log("focus true");
            //GameMeneger.S.SoundPlay();

        }
        else
        {
            //Time.timeScale = 0;
            //Debug.Log("focus false");
            //GameMeneger.S.SoundPause();
        }
    }
    void Start()
    {
        S = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
