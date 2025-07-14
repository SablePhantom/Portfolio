using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingSpotlight : MonoBehaviour

{

private Vector3 startAngle;

[SerializeField]

private float rotationSpeed = 1f;
[SerializeField]

private float rotationOffset = 50f;
private float finalAngle;
void Start()

{

startAngle = transform.eulerAngles;

}

void Update()

{

finalAngle = startAngle.y + Mathf.Sin(Time.time * rotationSpeed) * rotationOffset; // Calculate animation angle

transform.eulerAngles = new Vector3(startAngle.x, finalAngle, startAngle.z); // Apply the new angle to the object

}

}