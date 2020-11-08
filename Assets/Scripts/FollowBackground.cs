using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBackground : MonoBehaviour
{

    float parralax = 2f;

    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.y / transform.localScale.y / parralax;

        mat.mainTextureOffset = offset;

    }

}
