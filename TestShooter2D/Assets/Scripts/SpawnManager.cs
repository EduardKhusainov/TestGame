using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] spawnSectors;
   public float boundX = 6f;
   public float boundY = 2f;

    private void Start() 
    {
        RandomPos();    
    }
   public void RandomPos()
   {    
        int index = 0;
        for(int i = 0; i < spawnSectors.Length; i++)
        {
            int randomIndex = Random.Range(0, index);
            float startPosX = Random.Range(boundX, -boundX);
            float startPosY = Random.Range(boundY, -boundY);

            spawnSectors[index].transform.position = new Vector2(spawnSectors[index].transform.position.x + startPosX, spawnSectors[index].transform.position.y + startPosY);
            Instantiate(enemyPrefabs[randomIndex], spawnSectors[index].transform.position, transform.rotation);
            index++;
        }
   }
}
