using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;
    public Vector3 targetDirection;

    // Start is called before the first frame update
    void Start()
    {
        targetDirection = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetDirection, .125f);
    }
}
