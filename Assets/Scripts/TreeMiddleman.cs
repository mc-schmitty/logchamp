using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TreeMiddleman : MonoBehaviour
{
    public void Chop()
    {
        TreeManager treeMan = GetComponentInParent<TreeManager>();
        treeMan.Chop();
    }
}
