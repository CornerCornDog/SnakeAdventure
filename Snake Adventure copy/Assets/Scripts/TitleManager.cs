using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("levelOneStars"))
        {
            PlayerPrefs.SetInt("levelOneStars", 0);
            PlayerPrefs.SetInt("levelTwoStars", 0);
            PlayerPrefs.SetInt("levelThreeStars", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelSelectButton()
    {
        SceneManager.LoadScene(1);
    }
}
