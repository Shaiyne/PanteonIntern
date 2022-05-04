using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform to;

    private void Awake()
    {
        to = transform.GetChild(0).transform;
    }
    void Update()
    {
        if (transform.localPosition.y >= 6.5f)
        {
            this.gameObject.transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 6, -13), Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, to.rotation, Time.deltaTime);
        }
    }
}
