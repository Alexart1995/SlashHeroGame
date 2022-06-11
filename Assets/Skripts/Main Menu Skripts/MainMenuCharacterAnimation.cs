using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCharacterAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] animationSprites;

    private float timeTreshold = 0.07f;

    private float timer;

    private int state = 0;

    private Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    private void Update()
    {
        if (Time.time > timer)
        {
            img.sprite = animationSprites[state];
            state++;
            if (state == animationSprites.Length)
                state = 0;
            timer = Time.time + timeTreshold;
        }
    }
}
