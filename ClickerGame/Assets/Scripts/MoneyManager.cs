using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {
    
    #region Fields
    public Text Player_Cash;
    private ulong _current_player_cash = 1000;
    public Text Cash_Remaining_Txt;
    private ulong _cash_remaining = (75*20);
    public ulong Collision_value = 20;

    public ulong Current_Player_Cash
    {
        get { return _current_player_cash; }
        set { _current_player_cash = value; }
    }

    public ulong Cash_Remaining
    {
        get { return _cash_remaining; }
        set { _cash_remaining = value; }
    }
    #endregion
}
