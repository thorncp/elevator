using System;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject InnerDoor;
    public GameObject OuterDoor;
    public float DoorSpeed;

    private bool isOpening;
    private Vector3 startingInnerDoorPosition;
    private float innerDoorWidth;
    private const float Buffer = 0.001f;

    private void Start()
    {
        startingInnerDoorPosition = InnerDoor.transform.localPosition;
        innerDoorWidth = InnerDoor.GetComponent<Renderer>().bounds.size.z;
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isOpening = !isOpening;
        }

        if (isOpening && !IsOpen())
        {
            InnerDoor.transform.localPosition = new Vector3(
                InnerDoor.transform.localPosition.x + DoorSpeed,
                InnerDoor.transform.localPosition.y,
                InnerDoor.transform.localPosition.z
            );
            OuterDoor.transform.localPosition = new Vector3(
                OuterDoor.transform.localPosition.x + DoorSpeed * 2,
                OuterDoor.transform.localPosition.y,
                OuterDoor.transform.localPosition.z
            );
        }
        else if (!isOpening && !IsClosed())
        {
            InnerDoor.transform.localPosition = new Vector3(
                InnerDoor.transform.localPosition.x - DoorSpeed,
                InnerDoor.transform.localPosition.y,
                InnerDoor.transform.localPosition.z
            );
            OuterDoor.transform.localPosition = new Vector3(
                OuterDoor.transform.localPosition.x - DoorSpeed * 2,
                OuterDoor.transform.localPosition.y,
                OuterDoor.transform.localPosition.z
            );
        }
    }

    private bool IsClosed()
    {
        return DistanceFromStartingPosition() <= Buffer;
    }

    private bool IsOpen()
    {
        return DistanceFromStartingPosition() >= innerDoorWidth - Buffer;
    }

    private float DistanceFromStartingPosition()
    {
        return Math.Abs(InnerDoor.transform.localPosition.x - startingInnerDoorPosition.x);
    }
}