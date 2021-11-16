using UnityEngine;
using RPG.Attributes;
using GameDevTV.Inventories;
using RPG.Stats;
using System.Collections.Generic;

namespace Assets.All.GameDev.tv_Assets.Scripts.Inventories
{
    class Class1 : MonoBehaviour
    {

        private List<string> inventory = new List<string>();

        private void Start()
        {
            Debug.Log("it workes");
            Dn();
        }

         
        public Class1(List<string> items)
        {
            inventory = items;
        }

        public List<string> GetItems()
        {
            return inventory;
        }

        List<string> jacksItems = new List<string>();

        public void Dn()
        {
            jacksItems.Add("potion");
            jacksItems.Add("sword");
            Class1 jack = new Class1(jacksItems);

            List<string> jillsItems = jack.GetItems();
            jillsItems.Add("helmet");
            Class1 jill = new Class1(jillsItems);
            Debug.Log("iaaaaaaaaaaa");
        }
    }
}
