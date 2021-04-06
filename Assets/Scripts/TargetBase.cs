using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBase : MonoBehaviour
{
    protected bool hasHead;
    [SerializeField] private int team;
    AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        hasHead = true;
        sfx = GetComponent<AudioSource>();
        sfx.pitch = (Random.Range(0.7f, 1.2f));
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
            sfx.Play();
        }
    }
}
