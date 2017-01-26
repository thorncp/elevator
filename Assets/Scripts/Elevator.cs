using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject InnerDoor;
    public GameObject OuterDoor;
    public float DoorSpeed;

    private bool isOpening;
    private Vector3 closedInnerDoorPosition;
    private Vector3 closedOuterDoorPosition;
    private Vector3 openInnerDoorPosition;
    private Vector3 openOuterDoorPosition;
    private float innerDoorWidth;

    private float InnerDoorSpeed { get { return DoorSpeed * Time.deltaTime; } }
    private float OuterDoorSpeed { get { return InnerDoorSpeed * 2; } }

    private void Start()
    {
        closedInnerDoorPosition = InnerDoor.transform.localPosition;
        closedOuterDoorPosition = OuterDoor.transform.localPosition;
        innerDoorWidth = InnerDoor.GetComponent<Renderer>().bounds.size.z;
        openInnerDoorPosition = InnerDoor.transform.localPosition + Vector3.right * innerDoorWidth;
        openOuterDoorPosition = OuterDoor.transform.localPosition + Vector3.right * innerDoorWidth * 2;
    }

    private bool logged;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isOpening = !isOpening;
        }

        if (isOpening)
        {
            InnerDoor.transform.localPosition = Vector3.MoveTowards(
                InnerDoor.transform.localPosition,
                openInnerDoorPosition,
                InnerDoorSpeed
            );
            OuterDoor.transform.localPosition = Vector3.MoveTowards(
                OuterDoor.transform.localPosition,
                openOuterDoorPosition,
                OuterDoorSpeed
            );
        }
        else
        {
            InnerDoor.transform.localPosition = Vector3.MoveTowards(
                InnerDoor.transform.localPosition,
                closedInnerDoorPosition,
                InnerDoorSpeed
            );
            OuterDoor.transform.localPosition = Vector3.MoveTowards(
                OuterDoor.transform.localPosition,
                closedOuterDoorPosition,
                OuterDoorSpeed
            );
        }
    }
}