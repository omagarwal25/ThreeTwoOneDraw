using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class DefendLarge : AbstractDefend
{
    //0 argument constructor that makes a basic defense with size small
    public DefendLarge() : base("DefendLarge", 4, ImageLibrary.defend_art, "Negate any bullets within a LARGE window.", Type.Large) { }

    //When the card is played, make the LARGE defense invisible and destroy any bullets in the collider
    public override void use(AbstractPlayer user, float duration, TimeSlot slot)
    {
        DefenseManager.Instance.makeInvisible(this.TYPE);
        DefenseManager.Instance.defend(this.TYPE, user, PlayerDefense.DefenseType.Defend);
    }
}
