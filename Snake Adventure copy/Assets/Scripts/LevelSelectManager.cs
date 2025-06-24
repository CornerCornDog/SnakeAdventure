using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public GameObject levelOneStarOne, levelOneStarTwo, levelOneStarThree;
    public GameObject levelTwoStarOne, levelTwoStarTwo, levelTwoStarThree;
    public GameObject levelThreeStarOne, levelThreeStarTwo, levelThreeStarThree;
    // Start is called before the first frame update
    void Start()
    {
        checkStars();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void checkStars()
    {
        if(PlayerPrefs.GetInt("levelOneStars") >= 1)
        {
            levelOneStarOne.SetActive(true);
            if (PlayerPrefs.GetInt("levelOneStars") >= 2)
            {
                levelOneStarTwo.SetActive(true);
                if (PlayerPrefs.GetInt("levelOneStars") >= 3)
                {
                    levelOneStarThree.SetActive(true);
                }
                else
                {
                    levelOneStarThree.SetActive(false);
                }
            }
            else
            {
                levelOneStarTwo.SetActive(false);
                levelOneStarThree.SetActive(false);
            }
        }
        else
        {
            levelOneStarOne.SetActive(false);
            levelOneStarTwo.SetActive(false);
            levelOneStarThree.SetActive(false);
        }
        if (PlayerPrefs.GetInt("levelTwoStars") >= 1)
        {
            levelTwoStarOne.SetActive(true);
            if (PlayerPrefs.GetInt("levelTwoStars") >= 2)
            {
                levelTwoStarTwo.SetActive(true);
                if (PlayerPrefs.GetInt("levelTwoStars") >= 3)
                {
                    levelTwoStarThree.SetActive(true);
                }
                else
                {
                    levelTwoStarThree.SetActive(false);
                }
            }
            else
            {
                levelTwoStarTwo.SetActive(false);
                levelTwoStarThree.SetActive(false);
            }
        }
        else
        {
            levelTwoStarOne.SetActive(false);
            levelTwoStarTwo.SetActive(false);
            levelTwoStarThree.SetActive(false);
        }
        if (PlayerPrefs.GetInt("levelThreeStars") >= 1)
        {
            levelThreeStarOne.SetActive(true);
            if (PlayerPrefs.GetInt("levelThreeStars") >= 2)
            {
                levelThreeStarTwo.SetActive(true);
                if (PlayerPrefs.GetInt("levelThreeStars") >= 3)
                {
                    levelThreeStarThree.SetActive(true);
                }
                else
                {
                    levelThreeStarThree.SetActive(false);
                }
            }
            else
            {
                levelThreeStarTwo.SetActive(false);
                levelThreeStarThree.SetActive(false);
            }
        }
        else
        {
            levelThreeStarOne.SetActive(false);
            levelThreeStarTwo.SetActive(false);
            levelThreeStarThree.SetActive(false);
        }
    }
    public void resetScores()
    {
        PlayerPrefs.SetInt("levelOneStars", 0);
        PlayerPrefs.SetInt("levelTwoStars", 0);
        PlayerPrefs.SetInt("levelThreeStars", 0);
        checkStars();
    }
    public void levelSelected(int level)
    {
        SceneManager.LoadScene(level + 1);
    }
}
