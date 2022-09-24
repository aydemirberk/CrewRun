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


    void Start()
    {

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
