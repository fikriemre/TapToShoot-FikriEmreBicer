using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    
    private Camera _cam;

    public GameObject bombPrefab;
    public GameObject bulletPrefab;
    [HideInInspector]
    public UnityEvent onShoot;

    
    [SerializeField]
    private GameObject _projectilePrefab;

    private bool _inputEnabled = false;
    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Start()
    {
        SetProjectileType(Projectile.projectileType.Bullet);
    }

    public void DisableInput()
    {
        _inputEnabled = false;
    }

    public void EnableInput()
    {
        _inputEnabled = true;
    }
    public void SetProjectileType(Projectile.projectileType ptype)
    {
        if (ptype == Projectile.projectileType.Bomb)
        {
            _projectilePrefab = bombPrefab;
        }else if (ptype == Projectile.projectileType.Bullet)
        {
            _projectilePrefab = bulletPrefab;
        }
    }

    private void Update()
    {
        if(!_inputEnabled)
            return;
            
        if (Input.GetMouseButtonDown(0))
        { 
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        
        Ray spawnRay = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(spawnRay,out hit,250))
        {
            if(hit.collider.GetComponent<Brick>())
            {
                Instantiate(_projectilePrefab, spawnRay.origin, Quaternion.LookRotation(spawnRay.direction)).transform.parent = LevelManager.instance.transform;
                onShoot.Invoke();
            }
            
        }
        
        
    }
}