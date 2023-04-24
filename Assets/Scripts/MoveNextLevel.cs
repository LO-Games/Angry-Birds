using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextLevel : MonoBehaviour
{
    private string nextLevelName;
    private string currentLevelName;
    [SerializeField] float delay = 1f;

    void Awake()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(currentLevelName == "Level 1"){
            nextLevelName = "Level 2";
        }else if(currentLevelName == "Level 2"){
            nextLevelName = "Level 3";
        }else if(currentLevelName == "Level 3"){
            nextLevelName = "You Win";
        }
    }

    IEnumerator MoveNextLevelAfterSeconds(){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextLevelName);
    }

    
    // Update is called once per frame
    void Update()
    {
        currentLevelName = SceneManager.GetActiveScene().name;
        if(Destructibles.numOfPigs == 0){
            Destructibles.numOfPigs = 3;
            StartCoroutine(MoveNextLevelAfterSeconds());
        }
    }
}
