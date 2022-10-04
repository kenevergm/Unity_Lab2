using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab2 : MonoBehaviour
{
   public GameObject dragonEggPrefab;
    public float speed = 4;
    public float timeBetweenEggDrops = 2f;
    public float leftRightDistanse = 10f;
    public float chanceDirection = 0.01f;

    void Start()
    {
        Invoke("DropEgg", 2f);
    }

    void DropEgg(){
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(dragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
    }
    
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftRightDistanse){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistanse){
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate(){
        if (Random.value < chanceDirection){
            speed *= -1;
        }
    }
}
