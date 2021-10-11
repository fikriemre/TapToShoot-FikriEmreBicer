using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BrickBuilder : MonoBehaviour
{
    public GameObject BrickPrefab;
    public int rowCount = 1;
    public int columnCount = 1;
    public float brickSize = 1;

    public void Build()
    {
        Brick[] oldbricks = GetComponentsInChildren<Brick>();
        foreach (var oldbrick in oldbricks)
        {
#if UNITY_EDITOR
            DestroyImmediate(oldbrick.gameObject);
#else
               Destroy(oldbrick.gameObject);
#endif
        }

        for (int x = 0; x < rowCount; x++)
        {
            for (int y = 0; y < columnCount; y++)
            {
                Brick brick;

#if UNITY_EDITOR
                brick = ((GameObject) PrefabUtility.InstantiatePrefab(BrickPrefab, transform)).GetComponent<Brick>();
#else
                    brick = Instantiate(BrickPrefab, transform).GetComponent<Brick>();
#endif
                brick.transform.localPosition = new Vector3(x * brickSize, y * brickSize, 0);
                
                brick.transform.localScale = Vector3.one * brickSize;
                brick.transform.localPosition += brick.transform.localScale*0.5f;
            }
        }
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(BrickBuilder))]
public class BrickBuilderEditor : Editor
{
    private BrickBuilder builder;

    private void OnEnable()
    {
        builder = target as BrickBuilder;
    }

    public override void OnInspectorGUI()
    {
        int columnCount = EditorGUILayout.IntField($"ColumnCount: ", builder.columnCount);
        int rowCount = EditorGUILayout.IntField($"RowCount: ", builder.rowCount);
        float brickSize = EditorGUILayout.FloatField($"BrickSize: ", builder.brickSize);
        if (columnCount <= 0 || rowCount <= 0)
            return;
        if (Math.Abs(brickSize - builder.brickSize) > 0.01f)
        {
            builder.brickSize = brickSize;
            builder.Build();
        }
        if (columnCount != builder.columnCount)
        {
      
            builder.columnCount = columnCount;
            builder.Build();
        }

        if (rowCount != builder.rowCount)
        {
            builder.rowCount = rowCount;
            builder.Build();

        }
    }
}
#endif