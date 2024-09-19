using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform followTarget;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
    }
}
