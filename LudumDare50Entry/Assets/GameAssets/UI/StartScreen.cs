using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuinnLD.Core;
using UnityEngine.SceneManagement;

namespace QuinnLD.GUI
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private PlayerControls _input;
        [SerializeField] private int _targetScene;
        private void Update()
        {
            if (_input.Advancing)
            {
                SceneManager.LoadScene(_targetScene);
                if(Score.Instance != null)
                {
                    Score.Instance.ResetScore();
                }
                if (Timer.Instance != null)
                {
                    Timer.Instance.ResetTime();
                }
            }
            
        }
    }
}