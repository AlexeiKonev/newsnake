using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
 
    public class Bonus : MonoBehaviour
    {
        
        [SerializeField]
        private FoodData foodData;
        [SerializeField]
        private bool _isEated = false;
        [SerializeField]
        private Inventory _inventory;

        void Awake()
        {

        Destroy(this.gameObject, 8f);

        //StartCoroutine(DelayDelete());
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();

        //foodData = GetComponent<FoodData>();

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
            _inventory._bodyBonus = _inventory._bodyBonus + foodData.bodyBonus;
            _inventory._timeBonus = _inventory._timeBonus + foodData.timeBonus;
            _inventory._speedBonus = _inventory._speedBonus + foodData.speedBonus;

            _isEated = true;

            Destroy(this.gameObject);
        }

    }
