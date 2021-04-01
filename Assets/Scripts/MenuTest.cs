using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneOne()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }

    public void SceneTwo()
    {
        SceneManager.LoadSceneAsync("TargetPractice", LoadSceneMode.Single);
    }
    
    public void TimeTrial()
    {
        SceneManager.LoadSceneAsync("TimeTrial", LoadSceneMode.Single);
    }

    public void CabinBuild()
    {
        SceneManager.LoadSceneAsync("CabinBuild2", LoadSceneMode.Single);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("Title Menu", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
}
