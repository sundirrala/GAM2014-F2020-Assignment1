using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ArcherController : MonoBehaviour
{
    bool dropped = false;
    float fireSpeed = 1.0f;
    float nextFire = 0.0f;
    Vector2 target;

    [SerializeField]
    GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (!dropped)
        {
            bool pickedUp = false;
            foreach (var touch in Input.touches)
            {
                Vector3 world = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 worldPoint = new Vector2(world.x, world.y);
                transform.position = worldPoint;
                pickedUp = true;
            }
            if (!pickedUp)
            {
                dropped = true;
            }
        }
        else
        {
            nextFire += Time.deltaTime;
            if (nextFire >= fireSpeed)
            {
                GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
                if(go.Length > 0)
                {
                    Vector2 start = transform.position;
                    Vector2 target = go[0].transform.position;
                    GameObject gameObj = Instantiate(arrow, transform.position, quaternion.identity);
                    Vector2 vel = target - start;
                    float angle = Mathf.Atan2(vel.y, vel.x) - Mathf.PI / 2.0f;
                    Quaternion q = quaternion.identity;
                    q.SetEulerRotation(0.0f, 0.0f, angle);
                    gameObj.transform.rotation = q;
                    vel.Normalize();
                    vel *= 3.0f;
                    gameObj.GetComponent<Rigidbody2D>().velocity = vel;
                    nextFire = 0.0f;
                }



            }
        }

    }
}
