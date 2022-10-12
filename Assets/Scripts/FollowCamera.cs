using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _thingToFollow;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _thingToFollow.transform.position + new Vector3 (0, 0, -10);
    }
}
