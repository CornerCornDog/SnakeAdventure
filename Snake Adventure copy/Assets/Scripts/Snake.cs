using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Snake : MonoBehaviour
{
    //mobile controls
    public float minSwipeDistance = 0.25f;
    private float minSwipeDistancePixels;
    private Vector2 touchStart;
    public float speed;

    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;

    public GameObject loseLevelPanel;
    public TextMeshProUGUI foodCounter;
    private int foodCount;

    private Vector2 direction = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        loseLevelPanel.SetActive(false);
        minSwipeDistancePixels = minSwipeDistance * Screen.dpi;
        segments.Add(this.transform);
        foodCounter.text = "Food: " + foodCount;
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        if(direction == Vector2.left || direction == Vector2.right)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Vector2.down;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Vector2.right;
            }
        }
#elif UNITY_IOS || UNITY_ANDROID

#endif
    }
    private void FixedUpdate()
    {
        for(int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        this.transform.position = new Vector3((Mathf.Round(this.transform.position.x) + direction.x) , (Mathf.Round(this.transform.position.y) + direction.y), 0);
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
    }
    private void Lose()
    {
        loseLevelPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
