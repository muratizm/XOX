using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    int levels;
    [SerializeField] private bool unlocked;
    public Image[] unlockImages;

    private void Update()
    {
        UpdateLevelImage();
    }
 
    private void UpdateLevelImage()
    {
        levels = PlayerPrefs.GetInt("level");
        for (int i = 0; i < unlockImages.Length; i++)
        {
            //parse to int yapýyor stringi

            if (levels >= int.Parse(unlockImages[i].name))
            {
                unlockImages[i].gameObject.SetActive(false);
            }
            else
            {
                unlockImages[i].gameObject.SetActive(true);

            }
        }

        //if (!unlocked)
        //{
        //    unlockImages.gameObject.SetActive(true);

        //}
        //else
        //{
        //    unlockImages.gameObject.SetActive(false);
        //}
    }
    public void PressSelection(string _levelName)
    {
        if (unlocked)
        {
            SceneManager.LoadScene(_levelName);
        }
    }
}
    
    
