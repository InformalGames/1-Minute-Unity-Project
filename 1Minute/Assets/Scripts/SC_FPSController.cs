using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public GameObject PlayerBody;
    public GameObject GameControlOBJ;
    public Vector3 reset;
    public Vector3 crouch;
    public int numberofcards = 0;
    public int numberOfKeys = 0;
    public float walkingSpeed = 2f;
    public float runningSpeed = 4f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    public bool isRunning;


    [HideInInspector]
    public bool canMove = true;
    public bool CanSprint = true;
    public bool IsGamePaused = false;
    void Start()
    {
        crouch = new Vector3(1f, 0.4f, 1f);
        reset = new Vector3(1f, 1f, 1f);
        characterController = GetComponent<CharacterController>();

        //Get setting for game
        GameControlOBJ = GameObject.Find("GameController");
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (IsGamePaused == true) //paused game
        {
            canMove = false; //stop movement
        }
        else
        {
            //game not paused
            canMove = true;
            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);
        }
        IsGamePaused = GameControlOBJ.GetComponent<GameSetting>().PauseGame; //check if game is paused
        if (Input.GetKeyDown(KeyCode.LeftControl) && IsGamePaused == false)
        {
            walkingSpeed = 1f;
            runningSpeed = 1f;
            PlayerBody.transform.localScale = crouch;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && IsGamePaused == false)
        {
            walkingSpeed = 2f;
            runningSpeed = 4f;
            PlayerBody.transform.localScale = reset;

        }
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        PlayerSprintControl(Input.GetKey(KeyCode.LeftShift)); //check if player is trying to run, and the requirements are met for the player to be able to run
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
 

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded && IsGamePaused == false)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    void PlayerSprintControl(bool RunKeyPressed)
    {
        //stamina bar is filled
        if (GetComponent<StaminaControl>().CurrentStam > GetComponent<StaminaControl>().StamMin)
        {
            if (RunKeyPressed == true) //player is pressing run button
            {
                //game isnt paused
                if (GameControlOBJ.GetComponent<GameSetting>().PauseGame == false)
                {
                    isRunning = true;
                    GetComponent<StaminaControl>().CurrentStam -= 35.466f * Time.deltaTime; //decrease stamina
                }
            }
            else //player isnt pressing sprint button
            {
                isRunning = false;
                //game isnt paused
                if (GameControlOBJ.GetComponent<GameSetting>().PauseGame == false)
                {
                    GetComponent<StaminaControl>().CurrentStam += 12.222f * Time.deltaTime; //increase stamina
                }
            }
        }
        else
        {
            if (RunKeyPressed == false)
            {
                //game isnt paused
                if (GameControlOBJ.GetComponent<GameSetting>().PauseGame == false)
                {
                    GetComponent<StaminaControl>().CurrentStam += 12.222f * Time.deltaTime; //increase stamina
                }
            }
            //stamina ran out
            if (isRunning == true)
            {
                isRunning = false;
            }
        }
        //if player stopped running
        if (Input.GetKeyUp(KeyCode.LeftControl) && isRunning == true)
        {
            isRunning = false;
        }
    }
}