using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Camera;
    public bool endGame;
    [SerializeField] GameObject PlayerEndPosition;
    private Vector3 EndPos;

    private void Start()
    {
        EndPos = PlayerEndPosition.transform.position;


    }

    private void FixedUpdate()
    {
        if(!endGame)
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    private void Update()
    {
        if (endGame)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(EndPos.x, transform.position.y, EndPos.z), .005f);
        }

        else
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plus") || other.CompareTag("Minus") || other.CompareTag("Multiple") || other.CompareTag("Divide"))
        {
            int number = int.Parse(other.name);
            gameManager.SubCharacterControl(other.tag, number, other.transform);
            other.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.CompareTag("LevelEnd"))
        {
            Camera.GetComponent<CameraMove>().endGame = true;
            gameManager.ActivateEnemies();
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().TargetPoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            endGame = true;

        }
    }
}
