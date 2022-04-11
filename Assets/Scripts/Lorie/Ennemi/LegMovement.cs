using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
    public Transform raycastpoint;
    public Transform target;
    public Vector3 restingposition;
    public LayerMask mask;
    public Vector3 newposition;
    public Transform steppingPoint;
    public bool leggounded;
    public GameObject player;
    public float offset;
    public float movedDistance;
    public static int currentMoveValue = 1;
    public int moveValue;
    public float speed = 10f;
    public LegMovement otherleg;
    public bool hasMoved;
    public bool moving;
    public bool movinDown;

    private void Start()
    {
        restingposition = target.position;
        steppingPoint.position = new Vector3(restingposition.x + offset, restingposition.y, restingposition.z);

    }

    private void Update()
    {
        newposition = calculatepoint(steppingPoint.position);

        if(Vector3.Distance(restingposition, newposition) > movedDistance || moving && leggounded)
        {
            Step(newposition);
        }

        UdateIK();


    }

    public Vector3 calculatepoint(Vector3 position)
    {
        Vector3 dir = position - raycastpoint.position;
        RaycastHit hit;
        if(Physics.SphereCast(raycastpoint.position, 1f, dir, out hit, 5f, mask))
        {
            position = hit.point;
            leggounded = true;
        }
        else
        {
            position = restingposition;
            leggounded = false;
        }
        return position;
    }

    public void Step(Vector3 position)
    {
        if(currentMoveValue == moveValue)
        {
            leggounded = false;
            hasMoved = false;
            moving = true;

            target.position = Vector3.MoveTowards(target.position, position + Vector3.up, speed * Time.deltaTime);
            restingposition = Vector3.MoveTowards(target.position, position + Vector3.up, speed * Time.deltaTime);

            if(target.position == position + Vector3.up)
            {
                movinDown = true;
            }

            if(movinDown == true)
            {
                target.position = Vector3.MoveTowards(target.position, position, speed * Time.deltaTime);
                restingposition = Vector3.MoveTowards(target.position, position, speed * Time.deltaTime);
            }

            if(target.position == position)
            {
                leggounded = true;
                hasMoved = true;
                moving = false;
                movinDown = false;

                if(currentMoveValue == moveValue && otherleg.hasMoved == true)
                {
                    currentMoveValue = currentMoveValue * -1 + 3;
                }
            }
        }
    }

    public void UdateIK()
    {
        target.position = restingposition;
    }
}
