using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speen : MonoBehaviour
{
    public float speed = 0.2f;

    public enum RotationSpace
    {
        Local = 0,
        Global = 1
    }

    public RotationSpace rotationSpace = RotationSpace.Local;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);

        if (rotationSpace == RotationSpace.Local)
            transform.Rotate(0, speed, 0);
        else
            transform.Rotate(0, speed, 0, Space.World);
    }

}
