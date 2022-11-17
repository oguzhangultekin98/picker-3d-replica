using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform toFollow;
    [SerializeField] private TransformInterpolator transformInterpolater;

    private void LateUpdate()
    {
        if (!toFollow)
            return;
        Vector3 followingObjectLoc = toFollow.position;
        followingObjectLoc.x = 0f;

        var targetPos = followingObjectLoc;

        transform.position = Vector3.Lerp(transformInterpolater.oldVector, targetPos,
            transformInterpolater.vectorLerpCoefficient);

        transformInterpolater.oldVector = transform.position;
    }

    public void ChangeToFollow(Transform t)
    {
        toFollow = t;
        transformInterpolater.vectorLerpCoefficient = .1f;
    }
}