using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Canvas StartScreen;
    [SerializeField]
    Canvas EndScreen;
    public static UnityAction OnGameOver;
    private bool isPlaying = true;

    // Start is called before the first frame update
    private void Awake()
    {
        StartScreen.gameObject.SetActive(true);
        EndScreen.gameObject.SetActive(false);
    }

    void Start()
    {
        Pause();
        OnGameOver += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && StartScreen.gameObject.activeSelf)
        {
            Pause();
            StartScreen.gameObject.SetActive(false);
        }

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0) && StartScreen.gameObject.activeSelf)
        {
            Debug.Log("Game Start");
            Pause();
            StartScreen.gameObject.SetActive(false);
        }
#endif
    }

    private void GameOver()
    {
        Pause();
        EndScreen.gameObject.SetActive(true);
    }

    private void Pause()
    {
        isPlaying = !isPlaying;
        Debug.Log(Convert.ToInt32(isPlaying));
        Time.timeScale = Convert.ToInt32(isPlaying);
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
