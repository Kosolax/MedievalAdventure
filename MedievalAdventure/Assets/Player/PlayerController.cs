using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  
  public int speed = 5;
  private Vector3 DirectionDeplacement = Vector3.zero;
  private CharacterController Player;
  public int Sensibility;
  public int Jump = 5;
  public int Gravity = 20;
 
  void Start()
  {
    Player = GetComponent<CharacterController>();
  }
  // Update is called once per frame
  void Update () 
  {
    DirectionDeplacement.z = Input.GetAxis("Vertical");
    DirectionDeplacement.x = Input.GetAxis("Horizontal");
    DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);
    
    // Déplacement
    Player.Move(DirectionDeplacement * Time.deltaTime * speed);
    transform.Rotate(0, Input.GetAxisRaw("Mouse X")*Sensibility, 0);

    // Saut
    if(Input.GetKeyDown(KeyCode.Space) && Player.isGrounded)
    {
     DirectionDeplacement.y = Jump;
	}

    // Gravité
    if(!Player.isGrounded)
    {
     DirectionDeplacement.y -= Gravity * Time.deltaTime;
	}
  }
}