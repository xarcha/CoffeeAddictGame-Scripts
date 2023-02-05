using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform coffeeRoot;
    private List<Transform> coffees;
    public List<Vector3> coffeeDefaultPositions;
    public void Start()
    {
        FindCoffees();
        
    }

   
    private void FindCoffees()
    {
        coffees= new List<Transform>();
        coffeeDefaultPositions = new List<Vector3>();
        for (int i = 0; i < coffeeRoot.childCount; i++)
        {
            coffees.Add(coffeeRoot.GetChild(i).transform);
            coffeeDefaultPositions.Add(coffeeRoot.GetChild(i).transform.position);
        }
    }
    public void ResetLevel()
    {
        for (int i = 0; i < coffees.Count; i++)
        {
            coffees[i].position = coffeeDefaultPositions[i];
            coffees[i].SetParent(transform);
            coffees[i].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
