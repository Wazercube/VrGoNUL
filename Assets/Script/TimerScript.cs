using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    
    public float timer; // variable qui diminue au fil du temps et défini aussi le maximum du départ du timer
    private int timerInt; // Variable liée au timer mais sans le nombre après la virgule.
    public AnimationCurve animTimer; // Courbe d'animation qui définie la hauteur du nombre par rapport au temps.
    public AnimationCurve animfade; // Courbe d'animation qui définie l'alpha de l'affichage du nombre.
    public List<RectTransform> textGameObjects; // Liste des gameobjects a bouger
    private List<Text> texts; // Liste des Text à afficher
    private List<float> timerAnim; // Timer interne qui gere les animations.
    private short toUpdate; // Int qui gere lequel des objet est a modifié ( cad celui qui n'a pas été update depuis un moment)
    private bool stopAll = false; // Booléen qui gere l'arret total du timer ainsi que l'éffacement des numéro sur l'écran.
    private bool isTimerOn = false; // Booléen qui gere le démarrage du timer.

    /// <summary>
    /// Initialise le timer
    /// </summary>
    void Start()
    {
        timerInt = Mathf.FloorToInt(timer);
        timerAnim = new List<float>();
        timerAnim.Add(0);
        timerAnim.Add(0);

        texts = new List<Text>();
        texts.Add(textGameObjects[0].GetComponent<Text>());
        texts.Add(textGameObjects[1].GetComponent<Text>());       
    }

    /// <summary>
    /// Allume le Timer
    /// </summary>
    public void StartTimer()
    {
        isTimerOn = true;
    }

    /// <summary>
    /// Reset le timer en réinitialisant toute les variables.
    /// </summary>
    public void ResetTimer()
    {
        timerInt = Mathf.FloorToInt(timer);
        timerAnim = new List<float>();
        timerAnim.Add(0);
        timerAnim.Add(0);

        texts = new List<Text>();
        texts.Add(textGameObjects[0].GetComponent<Text>());
        texts.Add(textGameObjects[1].GetComponent<Text>());
    }

    /// <summary>
    /// Fonction pour redéfinir le temps restant au timer. Peut etre apelé meme lorsque le timer est en cour.
    /// </summary>
    /// <param name="p_timer"> Temps a set</param>
    public void SetTimer(float p_timer)
    {
        timer = p_timer;
        timerInt = Mathf.FloorToInt(timer);
    }

    /// <summary>
    /// Fonction pour ajouter du temps au timer. Peut etre appelé meme lorsque le timer est en cour.
    /// </summary>
    /// <param name="p_timer"></param>
    public void AddToTimer(float p_timer)
    {
        timer += p_timer;
        timerInt = Mathf.FloorToInt(timer);
    }

    /// <summary>
    /// Fonction appelé chaque tick lorsque le timer est actif. 
    /// </summary>
    private void TimerLife()
    {
        if (!stopAll)
        {
            timer -= Time.deltaTime;

            if (timer < (timerInt - 1))
            {
                ChangeNumber();
                if (timerInt <= -2)
                {
                    StopAll();
                    return;
                }
            }

            MoveGameObject(0);
            MoveGameObject(1);

            PhaseGameObject(0);
            PhaseGameObject(1);
            AddTimeToAnimTimer();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {

        if (isTimerOn)
        {
            TimerLife();
        }

    }

    /// <summary>
    /// Bouge l'objet "N" vers le haut suivant la courbe d'animation
    /// </summary>
    /// <param name="n"></param>
    void MoveGameObject(int n)
    {
        textGameObjects[n].transform.position = new Vector3(textGameObjects[n].transform.position.x, animTimer.Evaluate(timerAnim[n]) + 2, textGameObjects[n].transform.position.z);
    }

    /// <summary>
    /// Change l'alpha de l'objet "N" suivant la courbe d'animation
    /// </summary>
    /// <param name="n"></param>
    void PhaseGameObject(int n)
    {
        texts[n].color = new Color(texts[n].color.r, texts[n].color.g, texts[n].color.b, animfade.Evaluate(timerAnim[n]));
    }

    /// <summary>
    /// Fonction qui change le numéro a afficher ensuite.
    /// </summary>
    void ChangeNumber()
    {
        texts[toUpdate].text = timerInt.ToString();
        timerAnim[toUpdate] = 0;
        toUpdate++;
        toUpdate = (short)Mathf.Repeat(toUpdate, 2);
        timerInt--;        
    }

    /// <summary>
    /// Ajoute du temps suivant le timer de l'animation
    /// </summary>
    void AddTimeToAnimTimer()
    {
        for (int i = 0; i < 2; i++)
        {
            timerAnim[i] += Time.deltaTime;
        }
    }

    /// <summary>
    /// Stope le timer
    /// </summary>
    void StopAll()
    {
        isTimerOn = false;
        stopAll = true;
        texts[0].color = new Color(texts[1].color.r, texts[1].color.g, texts[1].color.b, 0.01f);
        
    }

}
