using UnityEngine;
using System.Collections;

/*
 * Title:       
 * Author:      Luna
 * Create Time: 2015/7/9 17:03:11
 */
public class DestroyOverBound : MonoBehaviour
{
    public void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
