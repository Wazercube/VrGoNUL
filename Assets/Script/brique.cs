using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class brique : MonoBehaviour
{
    public int HP;



    public void TakeDamage(int amount)
    {

        //Réduit la santé actuelle du montant des dégâts.
        HP -= amount;

        // Si la brique a tout perdu, sa santé n'ont pas encore été définis ...
        if (HP <= 0)
        {
            WordSettings.Instance.nbBriqueBrake++;
            // ... si devrais etre destruit...
            Destroy(gameObject);
        }
    }
    
}