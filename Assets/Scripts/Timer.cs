using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Tools;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    private TMP_Text timerText;
    private Cannon cannon;
    private float maxThrow;
    public float currentThrow;
    private MMProgressBar mMProgressBar;

    private void Start()
    {
        maxThrow = timeValue;
        timerText = GetComponentInChildren<TMP_Text>();
        cannon = FindObjectOfType<Cannon>();
        mMProgressBar = GetComponentInChildren<MMProgressBar>();
        InvokeRepeating("DisplayTime", 1f, 1f);
    }

    void Update()
    {

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            FindObjectOfType<GameManager>().FinishLevel(false);
            gameObject.SetActive(false);
        }

        //DisplayTime(timeValue);
    }

    void DisplayTime()
    {
        if (timeValue < 0)
        {
            timeValue = 0;
        }
        float minutes = Mathf.FloorToInt(timeValue / 60);
        float seconds = Mathf.FloorToInt(timeValue % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        currentThrow = timeValue;
        mMProgressBar.UpdateBar(currentThrow, 0f, maxThrow);

    }

}

