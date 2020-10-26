using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Transform target;
    private int pointNum = 0;

    [SerializeField]
    private float speed = 1.0f; // how fast the enemies move, will be editable in the inspector.

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
        Vector2 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextPoint();
        }
    }

    private void GetNextPoint()
    {
        if (pointNum > Waypoints.points.Length)
        {
            Destroy(gameObject);
            return;
        }
        pointNum++;
        target = Waypoints.points[pointNum];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "arrow")
        {
            Destroy(collision.gameObject);
        }
        
    }
}
