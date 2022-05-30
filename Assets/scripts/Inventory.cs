 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Inventory : MonoBehaviour
{


    public   int _bodyBonus=0;
    public   int _timeBonus=0;
    public   int _speedBonus=0;

    private  BodyGenerator _bodyGenerator;

    public bool _doubleBonusIsActive = false;
    public bool _timeBonusIsActive = false;
    public bool _speedBonusIsActive = false;

    [SerializeField] 
    Text textSpeedBonus;

    [SerializeField] 
    Text textTimeBonus;

    [SerializeField] 
    Text textBodyBonus;

    [SerializeField] 
    Text textBodyLeftTime;
     private SnakeControll _snakeControll;
     private  Body body;
   
    private void Awake()
    {
        _snakeControll = FindObjectOfType<SnakeControll>().GetComponent<SnakeControll>();
        _bodyGenerator = GameObject.Find("Generator").GetComponent<BodyGenerator>();
    }

    private void Update()
    {
        body = FindObjectOfType<Body>();
        textSpeedBonus.text = _speedBonus.ToString();
        textBodyBonus.text = _bodyBonus.ToString();
         
        textTimeBonus.text = _timeBonus.ToString();
        BonusCheck();

        // E for body x2 bonus
        if (Input.GetKeyDown(KeyCode.E) && _bodyBonus > 0  )
        {
            Debug.Log("body x2 bonus ");
            _bodyBonus--;
            _doubleBonusIsActive = true;
            
        }
        // Q for time bonus
        if (Input.GetKeyDown(KeyCode.Q) && _timeBonus > 0 && !_timeBonusIsActive)
        {
            Debug.Log("time bonus ");
            _timeBonus--;
             _timeBonusIsActive = true;
            ActivateTimeBonus();

        }
        else if (Input.GetKeyDown(KeyCode.Q) && _timeBonus > 0 &&  _timeBonusIsActive)
        {
            Debug.Log("time bonus steal active ");
        }

        //SPACE for speed bonus
        if (Input.GetKeyDown(KeyCode.Space) && _speedBonus > 0 && !_speedBonusIsActive)
        {
            Debug.Log("body bonus ");
            _speedBonus--;
           _speedBonusIsActive = true;
            ActivateSpeedBonus();
          
        }

         
    }
   

    void ActivateSpeedBonus()
    {
        if (_speedBonusIsActive)
        {
            _snakeControll.SpeedBoost();
            Debug.Log("speed boosted on 50");

            _speedBonusIsActive = false;
        }
    }
    
     
   void BonusCheck()
    {
        if (_bodyBonus < 0)
        {
            _bodyBonus = 0;
        }
        if (_speedBonus < 0)
        {
            _speedBonus = 0;
        }
        if (_timeBonus < 0)
        {
            _timeBonus = 0;
        }
    }
    void ActivateTimeBonus()
    {
        if (_timeBonusIsActive)
        {
            var tail = _bodyGenerator._bodyList.Peek().GetComponent<Body>() ;
            tail.SlowTimerSwitchOn();

             
            _timeBonusIsActive = false;
            Debug.Log(" Time bonus is Off");
            
        }
    }
   
   
}
 