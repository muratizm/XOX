using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.Tools;

public class RemaningThrowBar : MonoBehaviour
{
    private Cannon cannon;
    private float maxThrow;
    public float currentThrow;
    private MMProgressBar mMProgressBar;
    private GameManager gameManager;
    [SerializeField] TMP_Text counterText;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cannon = FindObjectOfType<Cannon>();
        mMProgressBar = GetComponentInChildren<MMProgressBar>();
        ChangerRemainingThrowBar();
    }


    public void ChangerRemainingThrowBar()
    {
        currentThrow = maxThrow - cannon.throwCounter;
        mMProgressBar.UpdateBar(currentThrow, 0f, maxThrow);
        counterText.text = currentThrow.ToString();
       
    }

    public void setMaxThrow(float max) 
    {
        maxThrow = max;
    }


    
}
