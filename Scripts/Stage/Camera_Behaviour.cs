using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour {
    private Vector3 offSet = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = new Vector3(0f, 0f, 0f);
    public float followDistance = 5f;
    public float pixelsPerUnit = 32f;
    private Vector3 lastPosition;

    //Player object
    [SerializeField] private Transform target;
    //Cursor object
    [SerializeField] private Transform direction;

	void Update () {
        MidPointFollow();
	}

    void LateUpdate(){
        PixelPerfectCam();
    }

    //Segue o ponto médio entre o Jogador e o Ponteiro
    void MidPointFollow(){
        //Consegue o ponto que será seguido
        Vector3 midPosition = (target.position + direction.position)/2 + offSet;
        //Posição do jogador para camera não abandonar ele, adicionando offset para não se encontrar na exata mesma posição
        midPosition = Vector3.ClampMagnitude(midPosition - target.position, followDistance) + target.position;

        transform.position = Vector3.SmoothDamp(transform.position, midPosition, ref velocity, smoothTime);
    }

    //Garante que os pixeis na imagem mantenham uma consistência
    void PixelPerfectCam(){
        Vector3 newPosition = transform.localPosition;
        Vector3 deltaPosition = newPosition - lastPosition;

        if (deltaPosition.sqrMagnitude > 0)
        {
            newPosition.x = Mathf.Round(newPosition.x * pixelsPerUnit) / pixelsPerUnit;
            newPosition.y = Mathf.Round(newPosition.y * pixelsPerUnit) / pixelsPerUnit;
            transform.localPosition = newPosition;
        }

        lastPosition = transform.localPosition;
    }
}
