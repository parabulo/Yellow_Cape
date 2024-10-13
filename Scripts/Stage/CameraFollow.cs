using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Vector3 offSet = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = new Vector3(0f, 0f, 0f);
    public float followDistance = 5f;
    public float heightOffset = 2f;

    //Player object
    [SerializeField] private Transform target;
    //Cursor object
    [SerializeField] private Transform direction;

	void Update () {
        MidPointFollow();
	}

    //Segue o ponto médio entre o Jogador e o Ponteiro
    void MidPointFollow(){
        //Consegue o ponto que será seguido
        Vector3 midPosition = (target.position + direction.position)/2 + offSet;
        //Posição do jogador para camera não abandonar ele, adicionando offset para não se encontrar na exata mesma posição
        Vector3 playerPos = target.position + new Vector3(0, heightOffset, 0);
        midPosition = Vector3.ClampMagnitude(midPosition - playerPos, followDistance) + playerPos;

        transform.position = Vector3.SmoothDamp(transform.position, midPosition, ref velocity, smoothTime);
    }
}
