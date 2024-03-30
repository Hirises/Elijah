using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Property : MonoBehaviour
{
    [OnValueChanged(nameof(On_isStatic))]
    public bool is_static = true;   //점프 초기화 여부 및 is_trigger 활성화 여부
    [OnValueChanged(nameof(On_isobject))]
    [SerializeField]
    public bool is_object = false;

    public bool is_interactable = false;    //상호작용 여부
    [ShowIf(nameof(is_interactable))]
    [Label("- interactable")]
    [SerializeField]
    public Object _interactable;
    public Interactable interactable;

    public bool is_triggable = false;   //닿았을때 상호작용 여부
    [ShowIf(nameof(is_triggable))]
    [Label("- triggable")]
    [SerializeField]
    private Object _triggable;
    public Triggable triggable;

    private void Awake()
    {
        if(_interactable != null) interactable = _interactable as Interactable;
        if(_triggable != null) triggable = _triggable as Triggable;
    }


    #region <CustomEditor>
    private void On_isStatic()
    {
        if (is_static)
        {
            gameObject.layer = Value.Layer.Layer_GroundNomal.num;
        }
        else
        {
            gameObject.layer = Value.Layer.Layer_Object.num;
        }
    }

    private void On_isobject()
    {
        if (is_object)
        {
            gameObject.layer = Value.Layer.Layer_Object.num;
        }
        else
        {
            gameObject.layer = Value.Layer.Layer_GroundNomal.num;
        }
    }
    #endregion

    #region <interactable>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(Value.Tag_Player) && is_triggable)
        {
            triggable.run_onInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(Value.Tag_Player) && is_triggable)
        {
            triggable.run_outInteraction();
        }
    }
    #endregion
}
