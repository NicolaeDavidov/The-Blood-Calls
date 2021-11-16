using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RPG.Stats
{
    public class ExperienceBar : MonoBehaviour
    {
        [SerializeField] Experience experience;
        private Slider slider;

        public float FillSpeed = 100f;

        private void Awake()
        {
            slider = gameObject.GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
            
             slider.value = experience.GetPoints();//+= FillSpeed * Time.deltaTime;
            
        }

        
    }
}

