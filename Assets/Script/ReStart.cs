using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReStart : MonoBehaviour


{

    private float timeBeforeRestart = 3f;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask))
        {

            if (hit.collider.name == "ReStart")
            {
                timeBeforeRestart -= 1 * Time.deltaTime;
                if (timeBeforeRestart <= 0f)
                {
                    WordSettings.Instance.GameOver();

                }
            }
            else
            {
                timeBeforeRestart = 3f;
            }

        }
    }
}
