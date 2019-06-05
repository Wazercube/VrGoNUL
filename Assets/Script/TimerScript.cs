using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer;
    private int timerInt;
    public AnimationCurve animTimer;
    public AnimationCurve animfade;
    public List<RectTransform> textGameObjects;
    private List<Text> texts;
    private List<float> timerAnim;
    private short toUpdate;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer<(timerInt-1))
        {
            ChangeNumber();
        }

        MoveGameObject(0);
        MoveGameObject(1);

        PhaseGameObject(0);
        PhaseGameObject(1);
        AddTimeToAnimTimer();
    }

    void MoveGameObject(int n)
    {
        textGameObjects[n].transform.position = new Vector3(textGameObjects[n].transform.position.x, animTimer.Evaluate(timerAnim[n]) + 2, textGameObjects[n].transform.position.z);
    }

    void PhaseGameObject(int n)
    {
        texts[n].color = new Color(texts[n].color.r, texts[n].color.g, texts[n].color.b, animfade.Evaluate(timerAnim[n]));
    }

    void ChangeNumber()
    {
        texts[toUpdate].text = timerInt.ToString();
        timerAnim[toUpdate] = 0;
        toUpdate++;
        toUpdate = (short)Mathf.Repeat(toUpdate, 2);
        timerInt--;        
    }

    void AddTimeToAnimTimer()
    {
        for (int i = 0; i < 2; i++)
        {
            timerAnim[i] += Time.deltaTime;
        }
    }
    

}
