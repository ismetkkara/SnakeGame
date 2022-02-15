using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chickencontrol : MonoBehaviour
{
    [SerializeField] private SnakeControl snake;
    public float minx, maxX, miny, maxy;
    void Start()
    {
        RandomChickenPosition();
    }

    private void RandomChickenPosition()
    {
        transform.position = new Vector2(
            Random.Range(minx, maxX),
            Random.Range(miny, maxy));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Snake"))
        {
            RandomChickenPosition();
            snake.CreateSegment();
        }
    }
}
