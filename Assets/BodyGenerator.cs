using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BodyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverPanel;

    //variable for   connect tails between self
    private  HingeJoint hingeJoint;
    //current count tails
    [SerializeField]
    private    int _countBody=0;
    //stack array where will storage new tails
    [SerializeField]
    private   Stack<GameObject> _bodyList = new Stack<GameObject>();
     //placement for attach prefab tail in inspector
    [SerializeField]
    private   GameObject _prefabBody;
    //variable for past tail
    [SerializeField]
    private GameObject _previousBody;
    //here will save new generated tail
    [SerializeField]
    private GameObject _newBody;
    //place for head is first element 
    [SerializeField]
    private GameObject _head;
    // UI timer 
    [SerializeField]
     private  Text timeText;
     private int _currentTime;
   
    void Start()
    {
        
       GameOverPanel.SetActive(false);

       _bodyList.Push(_previousBody);

         AddBody();

        
    }

    private void FixedUpdate()
    {
        GameOverShow();
    }
    void Update()
    {
        _currentTime = (int)_bodyList.Peek().GetComponent<Body>().TimeLife;
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


        AddFirstElement();

        //second   tail take coordinate of first tail  
        if (_countBody > 0)
        {
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


        hingeJoint.connectedBody = _previousBody.GetComponent<Rigidbody>();

       
        }

     

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
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            Debug.Log("GameOver");
        }
    }

  private void AddFirstElement()
    {
        //when game started tail take coordinate of head and backstep
        if (_countBody == 0)
        {
            Quaternion newQuant = new Quaternion(
                   _head.transform.rotation.x,
                   _head.transform.rotation.y,
                   _head.transform.rotation.z,
                   _head.transform.rotation.w
                   );
            Vector3 newPos = new Vector3(
                           _head.transform.localPosition.x,
                           _head.transform.localPosition.y,
                           _head.transform.localPosition.z - 2
                           );
            _newBody = Instantiate(
                   _prefabBody,
                   newPos,
                   newQuant
                   );

            hingeJoint = _previousBody.GetComponent<HingeJoint>();


            hingeJoint.connectedBody = _head.GetComponent<Rigidbody>();
        }
    }
}
