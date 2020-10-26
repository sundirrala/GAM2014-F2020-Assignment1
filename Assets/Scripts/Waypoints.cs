using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    void Awake()
    {
        points = new Transform[transform.childCount];
        // ----------------- looping through each waypoint, starting with the child point ----------------- //
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
