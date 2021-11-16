using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Attributes
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Health healthComponent = null;
        [SerializeField] Image foreground = null;
        [SerializeField] Canvas rootCanvas = null;
        public float speed = 5f;

        void Update()
        {
            if (Mathf.Approximately(healthComponent.GetFraction(), 0) || Mathf.Approximately(healthComponent.GetFraction(), 1))
            {
               
                return;
            }


            //foreground.localScale = new Vector3(healthComponent.GetFraction(), 1, 1);
            foreground.fillAmount = healthComponent.GetFraction();
        }
    }
}
