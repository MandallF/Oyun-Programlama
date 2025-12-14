using UnityEngine;

public class UcluLaser_sc : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject); 
        }
    }
}