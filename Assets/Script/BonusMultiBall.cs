using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMultiBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Shield")
        {
            Balle[] allBall = FindObjectsOfType<Balle>();
            foreach (Balle ball in allBall)
            {
                GameObject objBall = ball.gameObject;
                GameObject newBall = Instantiate(objBall, objBall.transform.position, objBall.transform.rotation);
                newBall.transform.Rotate(0, 45, 0, Space.Self);
                newBall.GetComponent<Balle>().LaunchBall();
                WordSettings.Instance.nbBalle++;
            }

            Destroy(gameObject);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Contains("DeadZone"))
        {
            Destroy(gameObject);
        }
    }
}
