using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticalGenerator : MonoBehaviour
{
    //obstical prefab
    [SerializeField] GameObject obs;

    /// <summary>
    /// holder is the parent of the fixed obsticals when they Instantiated.
    /// </summary>
    [SerializeField] Transform holder;

     GameObject[] obsticals; 
     int count;
     float Xpos;

    /// <summary>
    /// once the ground is first time activated, this function will be called to  Instantiate fixed obsticals on the graound, then store it in array.
    /// </summary>
    public void GenerateObs()
    {
        //choose random number of obsticals to generate.
        count = Random.Range(15, 20);

        //initilize the array of obsticals.
        obsticals = new GameObject[count];

        float Zpos = transform.position.z;
        for (int i = 0; i < count; i++)
            {
                Xpos = Random.Range(-9, 9);
                GameObject obst = Instantiate(obs, holder);
                obst.transform.position = new Vector3(Xpos, obst.transform.position.y, Random.Range((int)Zpos - 10, (int)Zpos + 10));  
                obsticals[i]= obst;
            }
  
    }


    /// <summary>
    /// once the ground is activated again, this function will be called to re position the stored fixed obsticals.
    /// </summary>
    public void UpdateObs()
    {
        
        float Zpos = transform.position.z;
        foreach (GameObject obstical in obsticals)
        {
             Xpos = Random.Range(-2, 4);
            //re position the fixed obsticals to be infront the player in random positions. 
            obstical.transform.position = new Vector3(obstical.transform.position.x+Xpos, obstical.transform.position.y,Random.Range((int)Zpos - 10, (int)Zpos + 10));
        }
    }
  
}
