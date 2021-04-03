using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{

    public WinCon winObject;
    public int treeCount;
    int choppedTrees;
    // Start is called before the first frame update
    void Start()
    {
        choppedTrees = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Chop()
    {
        choppedTrees++;
        if (choppedTrees == treeCount)
        {
            winObject.treesChopped();
        }
    }
}
