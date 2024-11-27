using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderManage : MonoBehaviour
{
    
     
    //corn
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement pm = PlayerMovement.Instance;
        GameManager manager = GameManager.Instance;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Corn"))
            {
                //Debug.Log(manager.currCorn);
                manager.currCorn++;
                Debug.Log("curr corn =" + manager.currCorn);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Tomato"))
            {
                manager.currTomato++;
                Debug.Log("curr tomato =" + manager.currTomato);
                Destroy(gameObject);
            }else if(gameObject.CompareTag("Cow") || gameObject.CompareTag("Chicken"))
            {
                pm.healt -= 1;

                if(pm.healt <= 0) { SceneManager.LoadScene(4); }
            }  

        }

        if (manager.currCorn == manager.maxCorn &&
            manager.currTomato == manager.maxTomato)
        {
            manager.maxCorn += 2;
            manager.maxTomato += 2;
            manager.ChangeScene("lvl2");
            Destroy(gameObject);
        }

        

    }
   
}
