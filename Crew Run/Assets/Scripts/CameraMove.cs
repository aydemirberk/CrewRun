using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;
    public Vector3 targetDirection;
    public bool endGame;
    public GameObject TargetPosition;

    void Start()
    {
        targetDirection = transform.position - target.position;
    }


    void LateUpdate()
    {
        if(!endGame)
        transform.position = Vector3.Lerp(transform.position, target.position + targetDirection, .125f);
        else
        {
            transform.position = Vector3.Lerp(transform.position, TargetPosition.transform.position, .01f);
        }

    }
}
