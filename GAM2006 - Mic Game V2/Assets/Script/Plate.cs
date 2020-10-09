using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public GameObject removeWall;

    public static bool risingThings;
    public List<GameObject> boulder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boulder.Count == 1)
        {
            risingThings = true;
        }

        if (boulder.Count == 2)
        {
            removeWall.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulders")
        {
            if (!boulder.Contains(other.gameObject))
            {
                boulder.Add(this.gameObject);
            }
        }
    }
}
