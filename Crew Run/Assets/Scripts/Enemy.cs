using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject AttackTarget;
    NavMeshAgent NavMesh;
    bool startFight;

    private void Start()
    {
        NavMesh = GetComponent<NavMeshAgent>();
    }

    public void AnimationTrigger()
    {
        GetComponent<Animator>().SetBool("Fight", true);
        startFight = true;
    }

    private void LateUpdate()
    {
        if (startFight)
        {
            NavMesh.SetDestination(AttackTarget.transform.position);
        }
    }
}
