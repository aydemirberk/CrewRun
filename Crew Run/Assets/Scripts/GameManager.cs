using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject TargetPoint;
    public int characterCounter;


    public List<GameObject> Characters;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var item in Characters)
            {
                if (!item.activeInHierarchy)
                {
                    item.transform.position = SpawnPoint.transform.position;
                    item.SetActive(true);
                    characterCounter++;
                    break;
                }
            }
        }        
    }

}
