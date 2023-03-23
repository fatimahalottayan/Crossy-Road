using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebleObsticals : MonoBehaviour
{
    /// <summary>
    ///  when the object reach this point, we will destroy it.
    /// </summary>
    float leftEdge;

    float movespeed;


    void Start()
    {
        
        leftEdge = -20;
        movespeed = Random.Range(5f, 9f);

    }

    void Update()
    {
      //make the object move from the spawner position to left.
       transform.Translate(Vector3.forward*movespeed*Time.deltaTime);


        //each frame check if the object reach the left edge to destroy it.
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
       
    }
}
