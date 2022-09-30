using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z), .3f);
            }

            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z), .3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plus") || other.CompareTag("Minus") || other.CompareTag("Multiple") || other.CompareTag("Divide"))
        {
            int number = int.Parse(other.name);
            gameManager.SubCharacterControl(other.tag, number, other.transform);
            other.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
