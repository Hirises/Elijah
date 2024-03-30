using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    #region <싱글톤>
    public static Util instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    public static void ChangeLayerforChild(GameObject obj, Value.Layer layer)
    {
        if (obj == null) return;
        foreach(Transform trans in obj.transform.GetComponentsInChildren<Transform>())
        {
            trans.gameObject.layer = layer.num;
        }
    }

    public static void ChangeLayerforChild(GameObject obj, Value.Layer layer, int maxcount)
    {
        if (obj == null) return;
        foreach (Transform trans in obj.transform.GetComponentsInChildren<Transform>())
        {
            trans.gameObject.layer = layer.num;
            maxcount--;
            if (maxcount <= 0) return;
        }
    }

    public static void SetGravity(float var)
    {
        Physics2D.gravity = new Vector2(0, var);
    }
}
