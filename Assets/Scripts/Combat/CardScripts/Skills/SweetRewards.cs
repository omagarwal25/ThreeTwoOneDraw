using UnityEngine;

public class SweetRewards : AbstractSkill
{
    public SweetRewards() : base("Sweet Rewards", 4, ImageLibrary.default_card, "Draw three cards instantly.") { }

    public override void use(AbstractPlayer user, float duration, TimeSlot slot){
        for (int i = 0; i < 3; i++)
        {
            EncounterControl.Instance.currPlayer.Draw();

        }
        EncounterControl.Instance.reapplyHand();
    }
}