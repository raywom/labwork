using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPoint : MonoBehaviour
{
    public static Transform transformPoint;

    void Start()
    {
        transformPoint = transform;
    }   
}
