using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsCycle : MonoBehaviour
{
    public List<CanvasGroup> Groups = new List<CanvasGroup>();
    public float Duration = 3.0f;

    private int position = 0;
    private float startTime = 0f;
    private bool fadeIn = true;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        var canvasGroup = Groups[position].GetComponent<CanvasGroup>();

        if (fadeIn)
        {
            if (Time.time - startTime < Duration)
            {
                var timeLeft = Duration - (Time.time - startTime);
                canvasGroup.alpha = (timeLeft / Duration * 100);
            }
            else
            {
                canvasGroup.alpha = 1;
                fadeIn = false;
            }
        }
        else
        {
            if (Time.time - startTime < Duration)
            {
                var timeLeft = Duration - (Time.time - startTime);
                canvasGroup.alpha = (timeLeft / Duration * 100);
            }
            else
            {
                canvasGroup.alpha = 0;
                fadeIn = true;
                if (position == (Groups.Count - 1))
                {
                    SceneManager.LoadScene("MainMenu");
                }
                else
                {
                    position++;
                    startTime = Time.time;
                }
            }
        }
    }
}
