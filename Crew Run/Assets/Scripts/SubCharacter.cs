using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubCharacter : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _Navmesh;


    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManager>().TargetPoint;
    }

    private void LateUpdate()
    {
        _Navmesh.SetDestination(Target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BadObject"))
        {
            Vector3 newPos = new Vector3(transform.position.x, .27f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().PlayDestroyEffect(newPos);
            gameObject.SetActive(false);
        }

    }
}