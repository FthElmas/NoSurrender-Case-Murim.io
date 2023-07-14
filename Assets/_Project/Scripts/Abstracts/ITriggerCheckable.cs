using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool IsTherePill {get; set;}

    bool IsThereCharacter {get; set;}

    

    void SetPillStatus(bool IsTherePill);

    void SetCharacterRangeStatus(bool IsThereCharacter);

    
}
