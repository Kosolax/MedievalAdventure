/* -------------------------------------------------------------- */
/* -----------All rights reserved to Medieval Adventure---------- */
/* -------------------------------------------------------------- */

using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController m_characterController;

    public List<Item> items;

    private float m_speed = 5f;

    public float exp = 0;

    public int lvl = 2;

    // Start is called before the first frame update
    internal void Start()
    {
        m_characterController = this.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.Deplacer();
    }

    private void Deplacer()
    {
        float l_horizontalInput = Input.GetAxis("Horizontal");
        float l_verticalInput = Input.GetAxis("Vertical");
        Vector3 l_direction = new Vector3(l_horizontalInput, 0, l_verticalInput);
        Vector3 l_velocity = l_direction * m_speed;
        m_characterController.Move(l_velocity * Time.deltaTime);
    }
}
