using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRotation : MonoBehaviour
{
    public void UpdateRotation(CatAngle angle)
    {
        float rotationAmount;

        if (angle == CatAngle.left)
        {
            rotationAmount = 0;
        }
        else if (angle == CatAngle.right)
        {
            rotationAmount = -180;
        }
        else if (angle == CatAngle.forwards)
        {
            rotationAmount = 90;
        }
        else
        {
            rotationAmount = -90;
        }
        Vector3 quaternion = new Vector3(0, rotationAmount, 0);
        transform.rotation = Quaternion.Euler(quaternion);
    }



}
public enum CatAngle
{
    left,
    right,
    forwards,
    backwards
}