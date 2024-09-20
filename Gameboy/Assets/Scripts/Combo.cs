using TMPro;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public static Combo Instance;
    [SerializeField] TMP_Text combo;
    [SerializeField] TMP_Text text;
    float comboCoolDown = 3f;
    float comboTimmer = 0;

    public int count = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetCombo()
    {
        combo.enabled = false;
        text.enabled = false;
        count = 0;
    }

    private void FixedUpdate()
    {
        if (comboTimmer > comboCoolDown)
        {
            combo.enabled = false;
            text.enabled = false;
            count = 0;
        }
        else
        {
            comboTimmer += Time.fixedDeltaTime;
        }
    }

    private void AddCombo(Enemy e)
    {
        comboTimmer = 0;
        count++;
        combo.text = count.ToString() + "X";

        combo.enabled = true;
        text.enabled = true;
    }

    private void OnEnable()
    {
        Enemy.die += AddCombo;
    }

    private void OnDisable()
    {
        Enemy.die -= AddCombo;
    }
}
