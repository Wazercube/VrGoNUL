using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BonusType { WEAPON, RACKET, BALL};

public class BonusToRecover : MonoBehaviour
{

    public BonusType type;
    [Range(0, 1)]
    public float rangeX;
    [Range(0, 1)]
    public float rangeY;

    [Range(0.01f,5)]
    public float speed = 0.01f;
    private GameObject Player;

    private Vector3 positionToReach;

    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        Random.seed = (int)System.DateTime.Now.Ticks;
        Player = GameObject.FindGameObjectWithTag("Player");
        positionToReach = Player.transform.position + new Vector3(Random.Range(-rangeX, rangeX), Random.Range(-rangeY, rangeY));
        Debug.Log(positionToReach);
        direction = positionToReach - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * (speed) * Time.deltaTime ;
    }
}
