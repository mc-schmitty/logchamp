using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCon : MonoBehaviour
{
    //The win con must track this one manually because there are never extreme numbers of cabins in one level
    //Give the number of cabins in this level
    public int cabins;
    int completedCabins;

    //These win cons are tracked by other managers
    public bool targets;
    public bool trees;

    bool targetsDone = false;
    bool treesDone = false;

    // Start is called before the first frame update
    void Start()
    {
        completedCabins = 0;
        if (!targets)
        {
            targetsDone = true;
        }
        if (!trees)
        {
            treesDone = true;
        }
    }

    public void CabinBuilt()
    {
        completedCabins++;
        winCheck();
    }

    public void treesChopped()
    {
        treesDone = true;
        winCheck();
    }

    public void targetUpdate(bool goodEnding)
    {
        if (goodEnding)
        {
            targetsDone = true;
            winCheck();
        }
        else
        {
            lose();
        }
    }

    void winCheck()
    {
        if (completedCabins == cabins && treesDone && targetsDone)
        {
            UnityEngine.Debug.Log("You win!");
        }
    }

    void lose()
    {

    }
}
