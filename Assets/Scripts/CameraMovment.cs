using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{

    [SerializeField] GameObject Player;

    Vector3 targetPos;
    Vector3 currentPos;
    Vector3 playerPos;
    float smooth = 0.03f;

    /// <summary>
    /// the distance between the player and camera.
    /// </summary>
    Vector3 offset;

    float yPos;


    void Start()
    {
        currentPos= transform.position;
        playerPos = Player.transform.position;

        //the distance between the player and camera.
        offset = currentPos - playerPos;

        yPos = currentPos.y;
    }

 
    void Update()
    {
        CameraMov();
    }


    /// <summary>
    /// this function will move the camera position based on player position, and adjust it by using the offset.
    /// </summary>
    void CameraMov()
    {
        playerPos = Player.transform.position;
        targetPos = playerPos + offset;
        currentPos = transform.position;


        Vector3 movment = Vector3.Lerp(currentPos, targetPos , smooth);
        movment.y = yPos;

        //we dont want the camera to move back, so when the player move back, we will freez the camera in Z axis.
        if (movment.z < currentPos.z )
        {
            movment.z = currentPos.z;
        }
        transform.position = movment;
      
    }
}
