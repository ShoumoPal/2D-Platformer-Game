using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private GameObject player;
    private Vector3 currentPosition;

    [SerializeField]
    private float skidValue;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentPosition = player.transform.position;
    }
    private void FixedUpdate()
    {
        if(player.transform.position.x != currentPosition.x)
        {
            Vector3 temp = transform.position;
            temp.x += (player.transform.position.x - currentPosition.x) * skidValue * Time.deltaTime;
            transform.position = temp;
        }
        if (player.transform.position.y != currentPosition.y)
        {
            Vector3 temp = transform.position;
            temp.y += (player.transform.position.y - currentPosition.y) * skidValue * Time.deltaTime;
            transform.position = temp;
        }
        currentPosition = player.transform.position;
    }
}
