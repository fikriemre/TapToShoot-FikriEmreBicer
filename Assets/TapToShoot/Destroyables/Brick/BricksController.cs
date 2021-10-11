using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BricksController : MonoBehaviour
{
    private Brick[] _bricks;
    public bool selectOneColorOnly = false;

    private void Start()
    {
        _bricks = GetComponentsInChildren<Brick>();
        LevelManager.instance.playerController.onShoot.AddListener(RandomizeBrickColors);
        RandomizeBrickColors();
    }

    void RandomizeBrickColors()
    {
        Color c=Color.white;
        if (selectOneColorOnly)
            c = new Color(Random.value, Random.value, Random.value, 1);
        foreach (var brick in _bricks)
        {
            if (!selectOneColorOnly)
                c = new Color(Random.value, Random.value, Random.value, 1);
            brick.SetColor(c);
        }
    }

    private void OnDestroy()
    {
        LevelManager.instance.playerController.onShoot.AddListener(RandomizeBrickColors);
    }
}