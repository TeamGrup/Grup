using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public GameObject pollutantCounter;
    public GameObject staticPollutantText;
    public float PulseDuration = 1.0f;
    TextMeshProUGUI text;
    RectTransform staticTextRect;
    RectTransform textRect;

    public GameObject pollutants;

    private float fPulseTimer;
    private bool bPulse;

    // Start is called before the first frame update
    void Start()
    {
        text = pollutantCounter.GetComponent<TextMeshProUGUI>();
        staticTextRect = staticPollutantText.GetComponent<RectTransform>();
        textRect = pollutantCounter.GetComponent<RectTransform>();
       
   
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateText();
        if (bPulse)
        {
            Debug.Log("Pulsing Text..");
            PulseText();
        }

        if (fPulseTimer < Time.time)
        {
            textRect.localScale = new Vector3(1, 1, 1);
            staticTextRect.localScale = new Vector3(1, 1, 1);
            bPulse = false;
        }
    }

    void UpdateText()
    {
        // text.text = pollutants.transform.childCount.ToString();
        var pol = GameObject.FindGameObjectsWithTag("Pollutant"); // ? update levels so we can just find the children of the pollutant objects
        text.text = pol.Length.ToString();
    }

    public void Pulse()
    {
        Debug.Log("Pulse Called...");
        fPulseTimer = Time.time + PulseDuration;
        bPulse = true;
    }

    private void PulseText()
    {
        var pulseVector = new Vector3(1+ Mathf.PingPong(Time.time, 0.20f), 1 + Mathf.PingPong(Time.time, 0.20f), 1 + Mathf.PingPong(Time.time, 0.20f));
        textRect.localScale = pulseVector;
        staticTextRect.localScale = pulseVector;
    }
}
