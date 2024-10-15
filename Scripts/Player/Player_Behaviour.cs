using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour {
    public float speed;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform pointer;
    [SerializeField] private Rigidbody2D rb;

	// Update is called once per frame
	void Update () {
        PlayerMovement();
	}

    //Movimento padrão
    void PlayerMovement(){
        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");
        Vector3 moveDiff = new Vector3(hmove, vmove).normalized;
        transform.position += moveDiff * speed * Time.deltaTime;
        rb.MovePosition(transform.position);
    }

    //Gerenciando estados de animação
    void Animado() {

    }
}