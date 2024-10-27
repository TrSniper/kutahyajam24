using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour
{
    [SerializeField] float timeLimit = 360f;
    [SerializeField] Image sanityBar;
    [SerializeField] Color sane;
    [SerializeField] Color insane;

    private Color color;
    private bool startFlag=false;

    void Start()
    {
        GameManager.Instance.OnGameStart += () => startFlag = true;
        color = sanityBar.color; 
    }

    void Update()
    {
        if (startFlag==false) return;
        timeLimit -= Time.deltaTime;
        sanityBar.fillAmount = timeLimit / 360f;
        color = Color.Lerp(insane, sane, sanityBar.fillAmount);
        sanityBar.color = color;
    }
}
