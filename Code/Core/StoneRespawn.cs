using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class StoneRespawn : MonoBehaviour
    {
        public bool activated = false;
        public ParticleSystem particles;

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            particles.gameObject.SetActive(activated);
        }

        private void OnTriggerEnter(Collider other)
        {
            SavingWrapper wrapper = FindObjectOfType<SavingWrapper>();
            if (other.gameObject.tag == "Player")
            {
                wrapper.Save();
                activated = true;
            }
        }


    }
}

