using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandomly : MonoBehaviour
{

    Vector3 direction;
    float x,y,z = 0;

    // Start is called before the first frame update
    void Start()
    {      
        direction = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        x += Random.Range(-1f * Time.deltaTime, 1f * Time.deltaTime);
        y += Random.Range(-1f * Time.deltaTime, 1f * Time.deltaTime);
        z += Random.Range(-1f * Time.deltaTime, 1f * Time.deltaTime);
        x = Mathf.Clamp(x, -1, 1);
        y = Mathf.Clamp(y, -1, 1);
        z = Mathf.Clamp(z, -1, 1);

        direction = new Vector3(x, y, z);
        transform.Rotate(direction , 180 * Time.deltaTime);
    }
}
