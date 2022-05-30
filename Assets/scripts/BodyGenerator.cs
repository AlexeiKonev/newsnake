using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyGenerator : MonoBehaviour
{
    [SerializeField]
    private   LevelManager _levelManager;
   //variable for   connect tails between self
    private new HingeJoint hingeJoint;
    //current count tails
    [SerializeField]
    private    int _countBody=0;
    //stack array where will storage new tails
 
    public Stack<GameObject> _bodyList = new Stack<GameObject>();

     //placement for attach prefab tail in inspector
    [SerializeField]
    private   GameObject _prefabBody;
    //variable for past tail
    public GameObject _previousBody;
    //here will save new generated tail
    [SerializeField]
    private GameObject _newBody;
    //place for head is first element 

     
    public bool ActiveBodyDouble;

    private Inventory _inventory;

    // UI timer 
    [SerializeField]
     private  Text timeText;
     private float _currentTime;
   
    void Awake()
    {
        _bodyList.Push(_previousBody);
         
        _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        ActiveBodyDouble = _inventory._doubleBonusIsActive;
        _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
      
        AddBody();

        
    }

    private void FixedUpdate()
    {
        GameOverShow();
    }
    void Update()
    {
        _currentTime =  _bodyList.Peek().GetComponent<Body>().TimeLife;

         timeText.text = _currentTime.ToString() ;
    }
     public  void AddBody()
    {

        _previousBody = _bodyList.Peek();

       

        if (_countBody!=0)
        {
            Body bodyPrev = _previousBody.GetComponent<Body>();

            bodyPrev.TimerOff();
            bodyPrev.SetFirsted();
        }
          //second   tail take coordinate of first tail  
         
            Quaternion newQuant = new Quaternion(
                   _previousBody.transform.rotation.x,
                   _previousBody.transform.rotation.y,
                   _previousBody.transform.rotation.z,
                   _previousBody.transform.rotation.w
                   );
            Vector3 newPos = new Vector3(
                           _previousBody.transform.localPosition.x,
                           _previousBody.transform.localPosition.y,
                           _previousBody.transform.localPosition.z - 2
                           );
            _newBody = Instantiate(
                   _prefabBody,
                   newPos,
                   newQuant
                   );

            hingeJoint = _newBody.GetComponent<HingeJoint>();
            Rigidbody rb= _previousBody.GetComponent<Rigidbody>();
            hingeJoint.connectedBody = rb;

       
        

     

        _newBody.GetComponent<Body>().SetLasted();
       
        _bodyList.Push(_newBody);
        _countBody++;

        Debug.Log("Body Attached");

        


    }

    //Destroy curent  tail and found last  in array ,then switch on DeathTimer 
    public void DeleteObj()
    {
        if (_countBody >  0) 
        {
            
            Destroy(_bodyList.Pop());
            Body body = _bodyList.Peek().GetComponent<Body>();
            body.SetLasted();
            body.DeathTimerOn = true;
            _countBody--;
        }
         
        
    }

    //show game over , when  tails is over
    private void GameOverShow()
    {
        if (_countBody == 0)
        {
            _levelManager.GameOver();
        }
    }

   
     
}
