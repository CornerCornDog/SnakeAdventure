using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    //mobile controls
    public float minSwipeDistance = 0.25f;
    private float minSwipeDistancePixels;
    private Vector2 touchStart;
    public float speed;

    public Transform snakeHead;

    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;

    public GameObject loseLevelPanel;
    public GameObject winLevelPanel;
    public GameObject star1, star2, star3;
    public TextMeshProUGUI foodCounter;
    private int foodCount;
    public TextMeshProUGUI foodEndText;

    private Vector2 direction = Vector2.right;

    private bool isGamePlaying;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        loseLevelPanel.SetActive(false);
        winLevelPanel.SetActive(false);
        foodCount = 0;
        minSwipeDistancePixels = minSwipeDistance * Screen.dpi;
        segments.Add(this.transform);
        foodCounter.text = "Food: " + foodCount;
        isGamePlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(direction == Vector2.left || direction == Vector2.right)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                snakeHead.rotation = Quaternion.Euler(0,0,90);
                direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                snakeHead.rotation = Quaternion.Euler(0, 0, -90);
                direction = Vector2.down;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                snakeHead.rotation = Quaternion.Euler(0, 0, 180);
                direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                snakeHead.rotation = Quaternion.Euler(0, 0, 0);
                direction = Vector2.right;
            }
        }
    }
    private void FixedUpdate()
    {
        if(isGamePlaying)
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].position = segments[i - 1].position;
            }
            this.transform.position = new Vector3((Mathf.Round(this.transform.position.x) + direction.x), (Mathf.Round(this.transform.position.y) + direction.y), 0);
        }
    }
    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            Grow();
            foodCount++;
            foodCounter.text = "Food: " + foodCount;
        }
        else if (other.tag == "Obstacle")
        {
            Lose();
        }
        else if (other.tag == "Key")
        {
            GameObject gate = other.GetComponent<Key>().gate;
            Destroy(gate);
            Destroy(other.gameObject);
        }
        else if (other.tag == "End")
        {
            Win();
        }
    }
    private void Lose()
    {
        loseLevelPanel.SetActive(true);
        isGamePlaying = false;
    }
    private void Win()
    {
        winLevelPanel.SetActive(true);
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            if (foodCount >= 5 || PlayerPrefs.GetInt("levelOneStars") >= 1)
            {
                LeanTween.scale(star1, new Vector3(1, 1, 1), 0.2f);
                if (PlayerPrefs.GetInt("levelOneStars") < 1)
                {
                    PlayerPrefs.SetInt("levelOneStars", 1);
                }
                if (foodCount >= 10 || PlayerPrefs.GetInt("levelOneStars") >= 2)
                {
                    LeanTween.scale(star2, new Vector3(1, 1, 1), 0.2f);
                    if (PlayerPrefs.GetInt("levelOneStars") < 2)
                    {
                        PlayerPrefs.SetInt("levelOneStars", 2);
                    }
                    if (foodCount == 15 || PlayerPrefs.GetInt("levelOneStars") >= 3)
                    {
                        LeanTween.scale(star3, new Vector3(1, 1, 1), 0.2f);
                        if (PlayerPrefs.GetInt("levelOneStars") < 3)
                        {
                            PlayerPrefs.SetInt("levelOneStars", 3);
                        }
                    }
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (foodCount >= 5 || PlayerPrefs.GetInt("levelTwoStars") >= 1)
            {
                LeanTween.scale(star1, new Vector3(1, 1, 1), 0.2f);
                if (PlayerPrefs.GetInt("levelTwoStars") < 1)
                {
                    PlayerPrefs.SetInt("levelTwoStars", 1);
                }
                if (foodCount >= 10 || PlayerPrefs.GetInt("levelTwoStars") >= 2)
                {
                    LeanTween.scale(star2, new Vector3(1, 1, 1), 0.2f);
                    if (PlayerPrefs.GetInt("levelTwoStars") < 2)
                    {
                        PlayerPrefs.SetInt("levelTwoStars", 2);
                    }
                    if (foodCount == 15 || PlayerPrefs.GetInt("levelTwoStars") >= 3)
                    {
                        LeanTween.scale(star3, new Vector3(1, 1, 1), 0.2f);
                        if (PlayerPrefs.GetInt("levelTwoStars") < 3)
                        {
                            PlayerPrefs.SetInt("levelTwoStars", 3);
                        }
                    }
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            if (foodCount >= 5 || PlayerPrefs.GetInt("levelThreeStars") >= 1)
            {
                LeanTween.scale(star1, new Vector3(1, 1, 1), 0.2f);
                if (PlayerPrefs.GetInt("levelThreeStars") < 1)
                {
                    PlayerPrefs.SetInt("levelThreeStars", 1);
                }
                if (foodCount >= 10 || PlayerPrefs.GetInt("levelThreeStars") >= 2)
                {
                    LeanTween.scale(star2, new Vector3(1, 1, 1), 0.2f);
                    if (PlayerPrefs.GetInt("levelThreeStars") < 2)
                    {
                        PlayerPrefs.SetInt("levelThreeStars", 2);
                    }
                    if (foodCount == 15 || PlayerPrefs.GetInt("levelThreeStars") >= 3)
                    {
                        LeanTween.scale(star3, new Vector3(1, 1, 1), 0.2f);
                        if (PlayerPrefs.GetInt("levelThreeStars") < 3)
                        {
                            PlayerPrefs.SetInt("levelThreeStars", 3);
                        }
                    }
                }
            }
        }
        foodEndText.text = "Food Collected: " + foodCount + " / 15";
        isGamePlaying = false;
    }    
}
