using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private List<GameObject> backgrounds = new List<GameObject>();
    [SerializeField] private float minY = 0;
    [SerializeField] private float maxY = 0;

    void Update()
    {
        for(int i = 0; i < backgrounds.Count; i++)
        {
            if (backgrounds[i].transform.position.y > maxY)
                backgrounds[i].transform.position += Vector3.down * 2.0f * Time.deltaTime;
            else
                backgrounds[i].transform.position = new Vector3(0.0f, minY, 0.0f);
        }
    }
}
