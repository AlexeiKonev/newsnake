using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 
    public class Bonus : MonoBehaviour
    {
        //[SerializeField]
        //private float _delayTimeDestroyItem = 2.5f;
        [SerializeField]
        private FoodData foodData;
        [SerializeField]
        private bool _isEated = false;
        [SerializeField]
        private Inventory _inventory;

        void Awake()
        {
            //StartCoroutine(DelayDelete());
            _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            foodData = GetComponent<FoodData>();

        }



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "snake" && !_isEated)
            {

                Eat();
            }
        }

        public void Eat()
        {
            _inventory.bodyBonus = _inventory.bodyBonus + foodData.bodyBonus;
            _inventory.timeBonus = _inventory.timeBonus + foodData.timeBonus;
            _inventory.speedBonus = _inventory.speedBonus + foodData.speedBonus;

            _isEated = true;

            Destroy(this.gameObject);
        }

    }
