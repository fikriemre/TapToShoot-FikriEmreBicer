using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    public enum projectileType
    {
        Bullet,
        Bomb
    }

    public float projectileSpeed = 2;

    private void Awake()
    {
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        Vector3 nextStep = transform.forward * (Time.deltaTime * projectileSpeed);

        Ray ray = new Ray(transform.position, nextStep);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, nextStep.magnitude))
        {
            OnExplotion(hit.collider.GetComponent<Destroyable>());
            Destroy(gameObject);
        }

        transform.position += nextStep;
    }

    protected virtual void OnExplotion(Destroyable target)
    {
        if (target)
            UIController.instance.ShowEndGameUI();
    }
}