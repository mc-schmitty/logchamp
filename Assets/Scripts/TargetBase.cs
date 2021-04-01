using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBase : MonoBehaviour
{
    protected bool hasHead;
    [SerializeField] private int team;

    // Start is called before the first frame update
    void Start()
    {
        hasHead = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Return team int
    public int getTeam()
    {
        return team;
    }

    public void LoseHead()
    {
        if(hasHead) {
            hasHead = false;
            GetComponentInParent<TargetManager>().LostHead(team);
        }
    }
}
