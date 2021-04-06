using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSpectators : MonoBehaviour
{

    public GameObject cabin;
    public GameObject tree;
    public GameObject target;

    WinCon levelConditions;
    // Start is called before the first frame update
    void Start()
    {
        levelConditions = GameObject.FindObjectOfType<WinCon>();
        if (levelConditions.targets)
        {
            target.SetActive(true);
        }
        if (levelConditions.trees)
        {
            tree.SetActive(true);
        }
        if (levelConditions.cabins > 0)
        {
            cabin.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
