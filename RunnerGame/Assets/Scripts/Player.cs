using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed;
    public int coffeeCount = 0;
    private GameManager gameManager;
    public List<GameObject> coffees;
    void Start()
    {
        coffees= new List<GameObject>();
        gameManager= GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private float firstTouchX;
    void Update()
    {
        if(gameManager.currentGameState !=GameState.Start)
        {
            return;
        }

        for (int i = 0; i < coffees.Count; i++)
        {
            coffees[i].transform.position = new Vector3(Mathf.Lerp(a:transform.position.x, b: coffees[i].transform.position.x, t: 0.01f*Time.deltaTime),coffees[i].transform.position.y, coffees[i].transform.position.z);
            //lerp ýký pozisyon arasýnda hafifce geçiþ
        }
        
        Vector3 moveVector= new Vector3(x:0,y:0,z:1*forwardSpeed*Time.deltaTime);
        float diff = 0;
        if (Input.GetMouseButtonDown(0))//týklayýp çektiyse down
        {
            firstTouchX = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0)) // basýlý tutuyosa sadece buttton
        {
            float lastTouchX = Input.mousePosition.x;
            diff = lastTouchX-firstTouchX;
            moveVector += new Vector3(x: diff * Time.deltaTime, y: 0, z: 0);
            firstTouchX= lastTouchX;
        }
        transform.position += moveVector;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.transform.SetParent(transform);
            coffees.Add(other.gameObject);
            coffeeCount++;
            
        }
        else if (other.CompareTag("Finish"))
        {
            
            if(coffeeCount == 0 )
            {
                gameManager.EndGame();
            }
            else
            {
                coffees[coffees.Count - 1].SetActive(false);
                coffees.RemoveAt(index:coffees.Count - 1);
                coffeeCount--;
            }
            

        }
    }
}
