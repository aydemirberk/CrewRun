using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Berk
{
    public class MathOperations : MonoBehaviour
    {
        public static void Multiple(int collidedNumber, List<GameObject> Characters, Transform spawnPos, List<GameObject> SpawnParticles)
        {

            int loopNumber = (GameManager.characterCount * collidedNumber) - GameManager.characterCount;
            int number = 0;

            foreach (var item in Characters)
            {

                if (number < loopNumber)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = spawnPos.position;
                        item.SetActive(true);

                        //For Particle Effects
                        foreach (var item2 in SpawnParticles)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = spawnPos.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }

                        number++;
                    }
                }

                else
                {
                    number = 0;
                    break;
                }

            }

            GameManager.characterCount *= collidedNumber;

        }

        public static void Plus(int collidedNumber, List<GameObject> Characters, Transform spawnPos, List<GameObject> SpawnParticles)
        {
            int number2 = 0;

            foreach (var item in Characters)
            {

                if (number2 < collidedNumber)
                {
                    if (!item.activeInHierarchy)
                    {
                        item.transform.position = spawnPos.position;
                        item.SetActive(true);

                        //For Particle Effects
                        foreach (var item2 in SpawnParticles)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = spawnPos.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }
                        }

                        number2++;
                    }
                }

                else
                {
                    number2 = 0;
                    break;
                }

            }
            GameManager.characterCount += collidedNumber;
        }

        public static void Minus(int collidedNumber, List<GameObject> Characters, List<GameObject> DestroyParticles)
        {

            if (GameManager.characterCount< collidedNumber)
            {
                foreach (var item in Characters)
                {
                    //For Particle Effects
                    foreach(var item2 in DestroyParticles)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            item2.SetActive(true);
                            item2.transform.position = item.transform.position;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }

                    item.SetActive(false);
                    item.transform.position = Vector3.zero;
                }

                GameManager.characterCount = 1;
            }

            else
            {
                int number3 = 0;

                foreach (var item in Characters)
                {

                    if (number3 != collidedNumber)
                    {
                        if (item.activeInHierarchy)
                        {
                            //For Particle Effects
                            foreach (var item2 in DestroyParticles)
                            {
                                
                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 newPos = new Vector3(item.transform.position.x, .27f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = newPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }

                            item.SetActive(false);
                            item.transform.position = Vector3.zero;
                            number3++;
                            GameManager.characterCount -= collidedNumber;
                        }
                    }

                    else
                    {
                        number3 = 0;
                        break;
                    }

                }
            }

        }

        public static void Divide(int collidedNumber, List<GameObject> Characters, List<GameObject> DestroyParticles)
        {
            if (GameManager.characterCount <= collidedNumber)
            {
                foreach (var item in Characters)
                {
                    //For Particle Effects
                    foreach (var item2 in DestroyParticles)
                    {

                        if (!item2.activeInHierarchy)
                        {
                            Vector3 newPos = new Vector3(item.transform.position.x, .27f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = newPos;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                    }

                    item.SetActive(false);
                    item.transform.position = Vector3.zero;
                }

                GameManager.characterCount = 1;
            }

            else
            {
                int divider = GameManager.characterCount / collidedNumber;
                int number4 = 0;

                foreach (var item in Characters)
                {
                    if (number4 != collidedNumber)
                    {
                        if (item.activeInHierarchy)
                        {
                            //For Particle Effects
                            foreach (var item2 in DestroyParticles)
                            {

                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 newPos = new Vector3(item.transform.position.x, .27f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = newPos;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }
                            }

                            item.SetActive(false);
                            item.transform.position = Vector3.zero;
                            number4++;
                        }
                    }

                    else
                    {
                        number4 = 0;
                        break;
                    }
                }

                if(GameManager.characterCount%collidedNumber == 0)
                {
                    GameManager.characterCount /= collidedNumber;
                }

                else if(GameManager.characterCount % collidedNumber == 1)
                {
                    GameManager.characterCount /= collidedNumber;
                    GameManager.characterCount++;
                }

                else if(GameManager.characterCount % collidedNumber==2)
                {
                    GameManager.characterCount /= collidedNumber;
                    GameManager.characterCount += 2;
                }
            }


            GameManager.characterCount /= collidedNumber;
        }
    }


}

