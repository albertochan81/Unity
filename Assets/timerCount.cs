using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timerCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiText; 
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce= false;

    // Start is called before the first frame update
    void Start()
    {
        timer = mainTimer;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = "Time: " +timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "Time: 0.00";
            timer = 0.0f;
        }
        
    }
    public void ResetTimer()
    {
        timer =mainTimer;
        canCount = true;
        doOnce= false;
    }
}
