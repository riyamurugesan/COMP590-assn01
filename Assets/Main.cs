using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Main : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;
    // Update is called once per frame
    
    void Start()
    {
        UpdateScore();
    }
    void Update()
    {

        if (Touchscreen.current.press.isPressed){
            Ray ray = Camera.main.ScreenPointToRay(Touchscreen.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.CompareTag("Correct Cube")){
                    score += 10;
                    UpdateScore();

                    hit.collider.gameObject.SetActive(false);
                }
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
