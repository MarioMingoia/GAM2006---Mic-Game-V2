using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class risingBoulder : MonoBehaviour
{
    public Vector3 destination;
    public int risingCount;

    public int incCount;
    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3(37.83f, 20.93f, -45);
        incCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Plate.risingThings == true)
        {
            if (transform.position.y < destination.y && risingCount == 0)
            {
                transform.Translate(0, 1, 0);
                print(incCount);
                incCount++;
            }

            if (incCount == 4)
            {
                this.GetComponent<risingBoulder>().enabled = false;
                risingCount = 1;
            }
        }
    }
}
