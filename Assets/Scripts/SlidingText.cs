using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingText : MonoBehaviour
{
    private Vector3 startingPoint = new Vector3(1800f, 0f, 0f);
    private float endingPoint = -1862f;
    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x <= endingPoint)
        {
            transform.localPosition = startingPoint;
        }
        transform.position -= new Vector3(0.25f, 0f, 0f);
    }
}
