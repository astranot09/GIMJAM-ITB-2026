using UnityEngine;

public class AwanScript : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float changeDistance = 0.2f;


    public Vector2 minArea = new Vector2(-8, -4);
    public Vector2 maxArea = new Vector2(8, 4);


    private Vector2 targetPos;


    void Start()
    {
        SetRandomTarget();
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetPos,moveSpeed * Time.deltaTime);


        if (Vector2.Distance(transform.position, targetPos) < changeDistance)
        {
            SetRandomTarget();
        }
    }


    void SetRandomTarget()
    {
        targetPos = new Vector2(
        Random.Range(minArea.x, maxArea.x),
        Random.Range(minArea.y, maxArea.y)
        );
    }
}