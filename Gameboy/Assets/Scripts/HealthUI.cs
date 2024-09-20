using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image[] healthImages;
    [SerializeField] private HealthSystem _healthSystem;
    public Sprite[] hearts;

    int currentLife = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth(_healthSystem.maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_healthSystem == null) return;
        UpdateHealth(_healthSystem.currentHealth);
    }

    private void UpdateHealth(int value)
    {
        if (value != currentLife)
        {
            currentLife = value;
            foreach(var image in healthImages)
            {
                if(value - 20 >= 0)
                {
                    image.sprite = hearts[0];
                    value -= 20;
                }
                else if (value - 10 >= 0)
                {
                    image.sprite = hearts[1];
                    value -= 10;
                }
                else
                {
                    image.sprite = hearts[2];
                }
            }
        }
    }
}
