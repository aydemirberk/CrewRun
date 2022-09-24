using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Berk;

public class GameManager : MonoBehaviour
{
    public GameObject TargetPoint;
    public static int characterCount = 1;
    public List<GameObject> Characters;


    void Start()
    {

    }


    public void SubCharacterControl(string operationType, int collidedNumber, Transform spawnPos)
    {
        switch (operationType)
        {
            case "Multiple":

                MathOperations.Multiple(collidedNumber, Characters, spawnPos);

                break;

            case "Plus":

                MathOperations.Plus(collidedNumber, Characters, spawnPos);

                break;

            case "Minus":

                MathOperations.Minus(collidedNumber, Characters);

                break;

            case "Divide":

                MathOperations.Divide(collidedNumber, Characters);
                break;

        }
    }

}
