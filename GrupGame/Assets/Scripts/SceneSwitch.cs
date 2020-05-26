using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("movement");
        }else if(Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("trampolenescene");
        }else if(Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("plantPick");
        }else if(Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene("ladderscene");
        }
    }
}
