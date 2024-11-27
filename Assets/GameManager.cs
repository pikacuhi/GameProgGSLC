using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public int maxTomato, maxCorn;
    public int currTomato, currCorn;
    public Text TomatoScore;
    public Text CornScore;
    public Text healtTxt;
    public PlayerMovement pm;
    
    private void Awake()
    {
        Instance = this;


        maxTomato = 2;
        maxCorn = 2;
    }
    void Start()
    {
        
    }

    void Update()
    {
        CornScore.text = "Corn: " + currCorn.ToString();
        TomatoScore.text = "Tomato: " + currTomato.ToString();
        healtTxt.text = pm.healt.ToString();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
