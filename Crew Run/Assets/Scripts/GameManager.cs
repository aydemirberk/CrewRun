using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Berk;

public class GameManager : MonoBehaviour
{
    public GameObject TargetPoint;
    public static int characterCount = 1;
    public List<GameObject> Characters;
    public List<GameObject> SpawnParticles;
    public List<GameObject> DestroyParticles;

    [Header("Level Datas")]
    public List<GameObject> Enemies;
    public int EnemyNumber;


    void Start()
    {
        SpawnEnemies();
    }


    public void SpawnEnemies()
    {
        for(int i = 0; i<EnemyNumber; i++)
        {
            Enemies[i].SetActive(true);
        }
    }

    public void ActivateEnemies()
    {

        foreach (var item in Enemies)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Enemy>().ActivateAnimation();
            }
        }
    }

    public void SubCharacterControl(string operationType, int collidedNumber, Transform spawnPos)
    {
        switch (operationType)
        {
            case "Multiple":

                MathOperations.Multiple(collidedNumber, Characters, spawnPos, SpawnParticles);

                break;

            case "Plus":

                MathOperations.Plus(collidedNumber, Characters, spawnPos, SpawnParticles);

                break;

            case "Minus":

                MathOperations.Minus(collidedNumber, Characters, DestroyParticles);

                break;

            case "Divide":

                MathOperations.Divide(collidedNumber, Characters, DestroyParticles);
                break;

        }
    }

    public void PlayDestroyEffect(Vector3 charPosition)
    {
        foreach (var item in DestroyParticles)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = charPosition;
                item.GetComponent<ParticleSystem>().Play();
                characterCount--;
                break;
            }
        }
    }

}
