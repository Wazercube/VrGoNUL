using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewScript : MonoBehaviour
{
    public LayerMask mask;
    public GameObject panier;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, mask))
        {
            panier.transform.position = hit.point;
            
            Debug.Log(hit.point);
        }
    }
}
