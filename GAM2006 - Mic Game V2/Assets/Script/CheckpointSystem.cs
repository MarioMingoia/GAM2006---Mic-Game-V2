using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 RespawnPoint;
    public CharacterController cc_Reference_To_Character_Controller;

    public bool isDead;

    private void Awake()
    {
        RespawnPoint = GameObject.Find("Player").transform.position;
    }
    void Start()
    {
        isDead = false;
        cc_Reference_To_Character_Controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true)
        {
            cc_Reference_To_Character_Controller.enabled = false;
            transform.position = RespawnPoint;
            cc_Reference_To_Character_Controller.enabled = true;
            isDead = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoints")
        {
            RespawnPoint = GameObject.Find("Player").transform.position;
        }

        if (other.gameObject.tag == "KillPlayer")
        {
            isDead = true;
        }
    }
}
