using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapMovement : MonoBehaviour {

    GameObject Player;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        Vector3 newPosition = Player.transform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
