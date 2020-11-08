using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlide : MonoBehaviour
{
    
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x -= Time.deltaTime;
        mat.mainTextureOffset = offset;

    }
}
