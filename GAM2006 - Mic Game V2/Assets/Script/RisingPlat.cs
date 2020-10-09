using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlat : MonoBehaviour
{
    public Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3(36.85f, 19.1f, -43.95f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Plate.risingThings == true)
        {
            if (transform.position.y < destination.y)
            {
                transform.Translate(0, 1, 0);
            }
        }
        
    }
}
