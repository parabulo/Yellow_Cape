using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair_Logic : MonoBehaviour {

    //Esse Script é feito para afetar somente o ponteiro da mira, alterando as suas animações e dando a certeza que ela vai se movimentar de forma fluida quando segue o ponteiro do mouse. Existe o script AIM_BEHAVIOUR que afeta o caso
    private Vector3 mousePosition;
    public float moveSpeed = 1.8f;
    [SerializeField] private Animator handAnimator;
    [SerializeField] private Transform player_weapon;

	// Use this for initialization
	void Start () {
        handAnimator = player_weapon.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        FollowCursor();
        AimRotation();
    }

    //Movimento de cursor
    void FollowCursor(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }

    //Faz com que o movimento do objeto mão siga o cursor conforme ele se movimenta pela tela
    void AimRotation(){
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Vector3 aimDirection = (worldMousePosition - player_weapon.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        player_weapon.eulerAngles = new Vector3(0, 0, angle);
    }

    //Função modular, considerando apenas o destino de ataque e a posição arma. Os diferentes projéteis terão seus trajetos processados dentro de seus próprios objetos
    // void AttackHandler(){
    //     if(Input.getMouseButtonDown(0)){
    //         handAnimator.SetTrigger("Bang");
    //     }
    // }
    
}