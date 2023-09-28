using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void LateUpdate()
    {
        if(playerTransform != null)
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
