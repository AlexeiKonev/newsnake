using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 attach to simple food for take new body part
 */
public  class Food : MonoBehaviour
{
    [SerializeField]
    private FoodData foodData;
     
     private  BodyGenerator _bodyGenerator;
     private bool _eated = false;

    private void Awake()
    {
 

         _bodyGenerator = FindObjectOfType<BodyGenerator>();
    }

    public virtual void Eat()
    {
        
        _bodyGenerator.AddBody();
         

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "snake"&& !_eated)
        {
            _eated = true;
            Eat();
            Destroy(this.gameObject);
        }
    }


}
