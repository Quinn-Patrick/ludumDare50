using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class LayoutManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _layouts = new List<GameObject>();
        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += UpdateLayout;
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= UpdateLayout;
        }
        private void UpdateLayout()
        {
            int layout = LevelManager.Instance.GetLevel() % _layouts.Count;

            for (int i = 0; i < _layouts.Count; i++)
            {
                if(i == layout)
                {
                    _layouts[i].SetActive(true);
                }
                else
                {
                    _layouts[i].SetActive(false);
                }
            }
        }

    }
}