using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float lerpAmounts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 desiredPos = new Vector3(target.position.x, 0, target.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPos, lerpAmounts);
    }
}
