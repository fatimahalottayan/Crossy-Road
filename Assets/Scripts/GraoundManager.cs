using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraoundManager : MonoBehaviour
{
    // array of graounds.
    [SerializeField] GameObject[] Graounds = new GameObject[3];

    [SerializeField] GameObject Spawner;
    [SerializeField] GameObject Player;

    int index;
    int lastindex;
   

    /// <summary>
    /// we need to activate a random graound in the beganing of the game.
    /// </summary>
    void Start()
    {
        //subsicribe to the player movment event, so we can detect when to generate a new graound.
        Player.GetComponent<PlayerMovment>().Moved += UpdateMove;
        //activate first graound.
        index = 0;
        Graounds[index].SetActive(true);
        //position this first graound in (0.0.0) point in cloud.
        Graounds[index].transform.position = new Vector3(0, 0,0);
        //generate the fixed obsticals of this graound.
        Graounds[index].GetComponent<ObsticalGenerator>().GenerateObs();
        lastindex = index;
    }

    /// <summary>
    /// this function will be executed once the player move to check the player Z position.
    /// </summary>
    void UpdateMove()
    {
        //if the player Z position is greater than the cuurent graound pivot point => we will activate a new ground infront of the current graound.
        if (Player.transform.position.z > Graounds[index].transform.position.z)
        {
            //call the spawner to generate a moveable obsticals.
            Spawner.GetComponent<spawner>().GenerateObst();

            // pick gandom graound to activate.
            index = Random.Range(0, 3);
         
            //make sure the new ground not the same of the current graound.
            while(index == lastindex)
            {
                index = Random.Range(0, 3);
            }
            Graounds[index].SetActive(true);

            //re position the new ground to be infornt of the current graound.
            Graounds[index].transform.position = new Vector3(Graounds[lastindex].transform.position.x, Graounds[lastindex].transform.position.y, Graounds[lastindex].transform.position.z + 40);

            //if the graound is first time generated we will GenerateObs() for it, else we will UpdateObs() its obsticals positions.
            if (Graounds[index].transform.childCount == 1)
            {
                Graounds[index].GetComponent<ObsticalGenerator>().GenerateObs();
            }
            else
            {
                Graounds[index].GetComponent<ObsticalGenerator>().UpdateObs();
            }

            lastindex = index;   
        }
    }

    public void Restart()
    {

        SceneManager.LoadScene(0);
    }
}
