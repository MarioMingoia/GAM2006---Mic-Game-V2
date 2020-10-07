using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMoveadRotate : MonoBehaviour
{
    public float fl_MovementSpeed = 6f;
    public float AirMovementSpeed = 3f;
    public float fl_gravity = 15f;
    public float fallMultiplier = 2.0f;

    private float speed;
    private Vector3 V3_move_direction = Vector3.zero;
    public static CharacterController cc_Reference_To_Character_Controller;

    // Start is called before the first frame update
    void Start()
    {
        cc_Reference_To_Character_Controller = GetComponent<CharacterController>();
        speed = fl_MovementSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (cc_Reference_To_Character_Controller.isGrounded)
        {
            
            MovePC(fl_MovementSpeed);

        }
        else
        {
            //AirMovementSpeed
            MovePC(AirMovementSpeed);
            V3_move_direction.y -= fl_gravity * Time.deltaTime;

        }

        cc_Reference_To_Character_Controller.Move(V3_move_direction);

    }
    void MovePC(float _speed)
    {
        Vector3 _temp_direction = Vector3.zero;

        _temp_direction.x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _temp_direction.z = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        V3_move_direction = gameObject.transform.TransformDirection(_temp_direction);
    }
}


