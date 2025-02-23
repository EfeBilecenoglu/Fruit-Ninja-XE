using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objsToSpawn;
    public GameObject bomb;
    public Transform[] spawnPlaces;
    public float minWait = .3f;
    public float maxWait = 1f;
    public float minForce = 12;
    public float maxForce = 17;
    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
        
    }
    public IEnumerator SpawnFruits()
    {
 
        while (true)  // as long as this code routitne runs, spawn fruits
        {
            
            yield return new WaitForSeconds(Random.Range(minWait, maxWait)); // define timing of the spawn
            Transform t= spawnPlaces[Random.Range(0,spawnPlaces.Length)]; //define location of the spawn

            /// <summary>
            /// Calling different types of objects to create in this game, using array and random.ranges methods. 
            /// </summary>
            GameObject go = null;
            float p = Random.Range(0, 100);
            if (p<10)
            {
                go = bomb;
            }
            else
            {
                go = objsToSpawn[Random.Range(0, objsToSpawn.Length)];
            }

            GameObject fruit = Instantiate(go, t.position, t.rotation);  //create clone
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);  //throw up the fruits
            Destroy(fruit,5); //delete old fruits
            
        }
   
    }

   
}
