using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public GameObject EndLevelScreen;
    public GameObject InGameScreen;
    public GameObject StartGameScreen;

  

    private void Awake()
    {
        instance = this;
        DisableAllPanels();
        StartGameScreen.SetActive(true);
    } 

    public void StartGame()
    {

        ShowIngameUI();
        LevelManager.instance.StartLevel();
    }

    private void DisableAllPanels()
    {
        InGameScreen.SetActive(false);
        EndLevelScreen.SetActive(false);
        StartGameScreen.SetActive(false);
    }
    public void ShowIngameUI()
    {
        DisableAllPanels();
        InGameScreen.SetActive(true);
    }
    public void ShowEndGameUI()
    {
        DisableAllPanels();
        EndLevelScreen.SetActive(true);
        LevelManager.instance.EndLevel();
    }

    public void SelectProjectileBomb()
    {
        SelectProjectile(Projectile.projectileType.Bomb);
    }

    public void SelectProjectileBullet()
    {
        SelectProjectile(Projectile.projectileType.Bullet);
    }

    public void SelectProjectile(Projectile.projectileType ptype)
    {
        LevelManager.instance.playerController.SetProjectileType(ptype);
    }
}