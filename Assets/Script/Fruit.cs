using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public string fruitName { get; set; }
    public GameObject slicedFruitPrefab;

    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        //Play Slice sound
        FindObjectOfType<GameManager>().PlayRandomSliceSound();

        Rigidbody[] rbsOnSliced = inst.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbsOnSliced)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(50, 100), transform.position, 5f);

        }
        switch (fruitName)
        {
            case "Orange(Clone)":
                FindObjectOfType<GameManager>().IncreaseScore(1);
                break;
            case "Watermelon(Clone)":
                FindObjectOfType<GameManager>().IncreaseScore(3);
                break;
            case "Banana(Clone)":
                FindObjectOfType<GameManager>().IncreaseScore(5);
                break;
        }

        Destroy(inst.gameObject,5);  // deleting slicedFruits after 5s.
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (!b) // if blade dont touch fruit
        { 
            return;
        }
        fruitName=gameObject.name; // get name of the fruit which get collosion with blade
        CreateSlicedFruit();
    }
}
