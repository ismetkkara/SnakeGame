using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeControl : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private GameObject segmentPrefab;
   
    private List<GameObject> segments = new List<GameObject>();
    void Start()
    {
        reset();
        ResetSegment();
    }

    
    void Update()
    {
        GetUserInput();
    }
   private void FixedUpdate()
    {
        SnakeMove();
        MoveSegment();
    }
    public void CreateSegment()
    {
        GameObject newSegment = Instantiate(segmentPrefab);
        newSegment.transform.position = segments[segments.Count - 1].transform.position;
        segments.Add(newSegment);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void reset()
    {
        _direction = Vector2.right;
        Time.timeScale = 0.1f;
    }



    private void ResetSegment()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i]);
        }
        segments.Clear();
        segments.Add(gameObject); 
        for (int i = 0; i < 3; i++)
        {
            CreateSegment();
        }
    }
    private void MoveSegment()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].transform.position=segments[i - 1].transform.position;
        }

    }
    
       
   
    private void SnakeMove()
    {
        float x,y;
        x = transform.position.x + _direction.x;
        y = transform.position.y + _direction.y;
        transform.position = new Vector2(x, y);
    }
    private void GetUserInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
      else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;

        }
       else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;

        }
      else  if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            RestartGame();
        }
    }
}
