using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class LevelManager : MonoBehaviour
{
    


    //star panel with start button and tutorial
    [SerializeField]
   private GameObject panelStart;
    //gameover  panel with restart level button and tutorial
    [SerializeField]
   private GameObject panelGameover;

    [SerializeField]
    private bool _isPlayed = false;
    public bool IsPlayed { get { return _isPlayed; } }

    private void Start()
    {

        //stop time of game before player will't push start button 
        Time.timeScale = 0;
        //will hide gameover panel 
        panelGameover.SetActive(false);

        //will show start panel 
        panelStart.SetActive(true);
        

    }


    public void StartPlay()
    {
        if (!_isPlayed)
        {
            _isPlayed = true;
            panelStart.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void RestartLevel ()
    {
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        if ( _isPlayed)
        {
            panelGameover.SetActive(true);
            Time.timeScale = 0;
            _isPlayed = false;
        }
    }

}
 