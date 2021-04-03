using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private int[] teamHeads;
    public WinCon winObject;

    // Start is called before the first frame update
    void Start()
    {
        // Setup all living targets
        teamHeads = new int[4];
        TargetBase[] tList = GetComponentsInChildren<TargetBase>();
        foreach (TargetBase t in tList)
        {
            teamHeads[t.getTeam()]++;
            //Debug.Log(teamHeads[t.getTeam()] + ", " + t.getTeam());
        }
    }

    // Updates Head number
    public void LostHead(int team) 
    {
        teamHeads[team] -= 1;

        //Team 0 is player, team 1 is enemy
        if(teamHeads[team] == 0 && team == 1) {
            Debug.Log("Team "+team+"'s targets have all been destroyed!");
            winObject.targetUpdate(true);
        }
    }
}
