using RPG.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar1 : MonoBehaviour
{

    [SerializeField] Health healthComponent = null;
    [SerializeField] Image foreground = null;

    // Start is called before the first frame update
    void Start()
    {
        healthComponent = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        foreground.fillAmount = healthComponent.GetHealthPercentage();
    }
}
