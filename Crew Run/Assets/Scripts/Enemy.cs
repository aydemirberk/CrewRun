using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject AttackTarget;
    private NavMeshAgent _NavMesh;
    private bool _startFight;
    private Transform _startPosition;

    private void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
    }

    public void ActivateAnimation()
    {
        GetComponent<Animator>().SetBool("Fight", true);
        _startFight = true;
    }

    private void LateUpdate()
    {
        if (_startFight)
        {
            _NavMesh.SetDestination(AttackTarget.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SubCharacter"))
        {
            Debug.Log("collided");
            Vector3 newPos = new Vector3(transform.position.x, .27f, transform.position.z);
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().PlayDestroyEffect(newPos);
            gameObject.SetActive(false);

        }
    }
            
}
