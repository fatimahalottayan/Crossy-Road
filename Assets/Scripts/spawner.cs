using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class spawner : MonoBehaviour
{


    // array of cars.
    [SerializeField] GameObject[] MoveableObsts = new GameObject[5];


    /// <summary>
    /// this variable will be changed with the player movment.
    /// </summary>
    Vector3 TargetPos;
    
   

    void Start()
    {
        TargetPos = transform.position;
    }
    void Update()
    {
        Detect();

    }

    /// <summary>
    /// this function will detect the player movment in each frame, and change the value of targetPos based on player Position.
    /// </summary>
    void Detect()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TargetPos.z++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TargetPos.z--;  
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TargetPos.x--;  
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TargetPos.x++;
          
        }
        if (Input.GetKeyDown("space"))
        {
            TargetPos.z += 5f;  
        }
    }


    /// <summary>
    /// this function will be called from the GraoundManager script, so will  Instantiate the moveable obsticals infront of the player.
    /// </summary>
    public void GenerateObst()
    {

        //choose random number of obsticals to generate.
        int random = Random.Range(8,12);
        float Xpos = TargetPos.x;
        float Zpos = TargetPos.z;
        float Ypos = 0;

        for (int i = 0; i < random; i++)
        {
            GameObject obstical = Instantiate(MoveableObsts[Random.Range(0, 4)], gameObject.transform);
            //re position the moveable obsticals to be infront the player. 
            obstical.transform.position  = new Vector3(Xpos , Ypos, Zpos);
            Xpos += Random.Range(3,7);
            Zpos += Random.Range(2,6);
        }
        
    }
}
