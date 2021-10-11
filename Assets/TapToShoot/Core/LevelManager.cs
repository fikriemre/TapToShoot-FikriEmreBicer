using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public PlayerController playerController;

    private void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
 
    public void StartLevel()
    {
        playerController.EnableInput();
    }
    public void EndLevel()
    {
        playerController.DisableInput();
    }
}
