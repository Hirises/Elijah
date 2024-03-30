using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{
    #region <키>
    public static KeyCode Key_LeftMove = KeyCode.A;
    public static KeyCode Key_RightMove = KeyCode.D;
    public static KeyCode Key_Jump = KeyCode.W;
    public static KeyCode Key_Sit = KeyCode.S;
    public static KeyCode Key_Snake = KeyCode.LeftShift;
    public static KeyCode Key_Intract = KeyCode.Q;
    #endregion

    #region <플레이어>
    public static int Player_MoveSpeed = 3;
    public static int Player_JumpHight = 7;
    public const float Player_JumpDelayTime = 0.1f;
    #endregion

    #region <씬/레이어/태그>
    public class Layer
    {
        public static Layer Layer_PlayerNomal = new Layer(8);
        public static Layer Layer_PlayerSnake = new Layer(9);
        public static Layer Layer_GroundNomal = new Layer(10);
        public static Layer Layer_Object = new Layer(11);

        public int num;

        private Layer(int layernum)
        {
            num = layernum;
        }
    }

    public const string Tag_Player = "Player";
    public const string Tag_MainCamera = "MainCamera";
    #endregion

    #region <싱글톤>
    public static Value instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
