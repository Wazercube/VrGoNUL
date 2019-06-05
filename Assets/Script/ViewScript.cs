using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewScript : MonoBehaviour
{
    public LayerMask mask;
    public GameObject panier;
    public GameObject balle;
    private Balle scriptBalle;
    private float timeBeforeLaunch;
    public float offset;
    // Start is called before the first frame update

    void Start()
    {
        timeBeforeLaunch = 3f;
        scriptBalle = balle.GetComponent<Balle>();
        WordSettings.Instance.CheckBrique();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask))
        {
            panier.transform.position = hit.point;
            
          
        }

        if(timeBeforeLaunch>0)
        {
            balle.transform.position = hit.point + transform.forward * offset;
            balle.transform.rotation = transform.rotation;
            timeBeforeLaunch -= 1 * Time.deltaTime;

            if(timeBeforeLaunch<0)
            {
                scriptBalle.LaunchBall();
            }
        }



    }

    public float TimeBeforeLaunch
    {
        get
        {
            return timeBeforeLaunch;
        }
        set
        {
            timeBeforeLaunch = value;
        }
    }

}

