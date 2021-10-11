using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _renderer;

    public void SetColor(Color c)
    {
        _renderer.material.SetColor("_BaseColor",c);
    }
 
}
