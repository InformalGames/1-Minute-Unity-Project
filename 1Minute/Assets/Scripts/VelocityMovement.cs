using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMovement : MonoBehaviour
{
    public float MoveForceX;

    public float MoveForceZ;

    public bool MoveOnX; //move on x axis //negative is left, postive is right

    bool GamePaused;

    public bool MoveOnZ; //move on Z axis //negative is backwards, postive is forwards
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GamePaused = GameObject.Find("GameController").GetComponent<GameSetting>().PauseGame;
    }

    void OnTriggerStay(Collider collision)
    {
        if (GamePaused == false)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Entity"))
            {
                MoveEntity(collision.gameObject);
            }
            if (collision.gameObject.tag == "Player")
            {
                MovePlayer(collision.gameObject);
            }
        }
        
    }
    
    void MoveEntity(GameObject OtherObj)
    {
        if (MoveOnX == true)
        {
            
        }
        if (MoveOnZ == true)
        {

        }
    }

    void MovePlayer(GameObject PlayerObj)
    {
        if (MoveOnX == true)
        {
            PlayerObj.GetComponent<SC_FPSController>().VelocityX = MoveForceX;
        }   

        if (MoveOnZ == true)
        {
            PlayerObj.GetComponent<SC_FPSController>().VelocityZ = MoveForceZ;
        }
    }
}
