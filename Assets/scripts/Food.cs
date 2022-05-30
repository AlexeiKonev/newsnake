using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 attach to simple food for take new body part
 */
public  class Food : MonoBehaviour
{
    //[SerializeField]
    //private FoodData foodData;
     
     private  BodyGenerator _bodyGenerator;
     private bool _eated = false;

    private void Awake()
    {
        _bodyGenerator = FindObjectOfType<BodyGenerator>();
        Destroy(this.gameObject,20f);
    }

    public   void Eat()
    {
     
            _bodyGenerator.AddBody();
         
     }
         

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "snake"&& !_eated)
        {
            if (!_bodyGenerator.ActiveBodyDouble) {
                _eated = true;
                Eat();
                Destroy(this.gameObject);
            }

            if ( _bodyGenerator.ActiveBodyDouble)
            {
                _eated = true;
                Eat();
                Eat();
                _bodyGenerator.ActiveBodyDouble = false;
                Destroy(this.gameObject);
            }
            

        }
    }


}
