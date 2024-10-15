using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Apenas organizando os atributos e métodos gerais que um inimigo necessita

public class GenericENemy : MonoBehaviour {
	//Atributos de Inimigo(Todos públicos e prontos para alteração, caso queira criar uma variação com mais vida ou que cause mais dano)
	public int hp;
	public float attentionRange;
	public float speed;
	public float strength;
	public bool floater = false;
	public bool aggressive = false;
	public bool invincible = true;

	//Avaliar se o combate é necessário um campo de visão em que o inimigo detecta o jogador, ou fazer com que o inimigo apenas detecte a posição do jogador (Talvez utilizar campos de visão para lidar com obstáculos).
	private Transform player;
	private Rigidbody2D rb;
	private Vector2 movement;
}
