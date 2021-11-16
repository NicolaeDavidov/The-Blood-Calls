using System.Collections;
using System.Collections.Generic;
using GameDevTV.Inventories;
using RPG.Stats;
using UnityEngine;

namespace RPG.Inventories
{
    [CreateAssetMenu(menuName = ("Inventory/Equipable Item"))]
    public class StatsEquipableItem : EquipableItem, IModifierProvider
    {
        [SerializeField]
        Modifier[] additiveModifiers;
        [SerializeField]
        Modifier[] percentageModifiers;


        [System.Serializable]
        struct Modifier
        {
            public Stat stat;
            public float value;
            public float minValue;
            public float maxValue;
            public float x;
           
        }

        
        public IEnumerable<float> GetAdditiveModifiers(Stat stat)
        {
            foreach (var modifier in additiveModifiers)
            {
                if (modifier.stat == stat)
                {
                    //float value = Random.Range(modifier.minValue, modifier.maxValue);
                    Debug.Log("value: " + modifier.value);

                    yield return modifier.value;
                }
            }
        }

        public IEnumerable<float> GetPercentageModifiers(Stat stat)
        {
            foreach (var modifier in percentageModifiers)
            {
                if (modifier.stat == stat)
                {

                    yield return modifier.value;
                }
            }
        }
    }
    
}