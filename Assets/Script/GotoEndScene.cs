using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoEndScene : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update

    
    public void EndScene()
     {
        if (Time.timeScale == 0f)
        {
            go.SetActive(true);
            SceneManager.LoadScene("RealEndScene");

        }
         
     }
}
