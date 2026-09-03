using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MedallionDoor : MonoBehaviour
{
    [Header("Door")]
    public Transform leftDoor;
    public Transform rightDoor;

    public float openDistance = 2f;
    public float openSpeed = 3f;

    [Header("Input")]
    public InputActionReference openDoorAction;

    private bool playerNearby = false;
    private bool doorOpening = false;

    private Vector3 leftClosedPosition;
    private Vector3 rightClosedPosition;

    private Vector3 leftOpenPosition;
    private Vector3 rightOpenPosition;

    // Start is called before the first frame update
    void Start()
    {
        leftClosedPosition = leftDoor.position;
        rightClosedPosition = rightDoor.position;

        leftOpenPosition =
            leftClosedPosition + Vector3.left * openDistance;

        rightOpenPosition =
            rightClosedPosition + Vector3.right * openDistance;
    }
    void OnEnable()
    {
        if (openDoorAction != null)
        {
            openDoorAction.action.Enable();
        }
    }

    void OnDisable()
    {
        if (openDoorAction != null)
        {
            openDoorAction.action.Disable();
        }
    }

    void Update()
    {
        if (playerNearby &&
             openDoorAction != null &&
             openDoorAction.action.WasPressedThisFrame())
        {
            OpenDoor();
        }

        if (doorOpening)
        {
            leftDoor.position = Vector3.MoveTowards(
                leftDoor.position,
                leftOpenPosition,
                openSpeed * Time.deltaTime
            );

            rightDoor.position = Vector3.MoveTowards(
                rightDoor.position,
                rightOpenPosition,
                openSpeed * Time.deltaTime
            );
        }
    }

    void OpenDoor()
        {
            if (doorOpening)
            {
                return;
            }

            if (MedallionManager.Instance == null)
            {
                Debug.LogError("MedallionManager is missing!");
                return;
            }

            if (MedallionManager.Instance.UseMedallion())
            {
                doorOpening = true;

                Debug.Log("MEDALLION INSERTED!");
            }
            else
            {
                Debug.Log("You need a medallion!");
            }
        }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;

            Debug.Log("Player is near the door.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;

            Debug.Log("Player left the door.");
        }
    }
}
