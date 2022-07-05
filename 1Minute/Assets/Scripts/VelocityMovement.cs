using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMovement : MonoBehaviour
{
    public float MoveForceX; //negative value to move left on x axis

    public float MoveForceZ; //negative value to move back on z axis

    public bool MoveOnX; //move on x axis 

    bool GamePaused;

    public bool MoveOnZ; //move on Z axis 
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
            PlayerObj.transform.Translate(Vector3.right * MoveForceX * Time.deltaTime, Space.Self);
        }   

        if (MoveOnZ == true)
        {
            PlayerObj.transform.Translate(Vector3.forward * MoveForceZ * Time.deltaTime, Space.Self);
        }
    }
}
