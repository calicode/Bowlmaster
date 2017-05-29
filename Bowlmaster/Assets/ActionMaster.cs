using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionMaster
{
    public enum Action { Tidy, Refresh, EndGame, EndTurn };
    private int[] bowls = new int[22];
    private int currentBowl = 0;
    private bool bowl21Enabled = false;

    bool CheckSpare(int bowl1, int bowl2)
    {
        return (bowl1 + bowl2 == 10);


    }

    public Action Bowl(int pins)
    {

        currentBowl++;
        bowls[currentBowl] = pins;

        Debug.Log("Currwntbowl is" + currentBowl);

        if (pins < 0 || pins > 10) { throw new UnityException("ActionMaster got out of range pin count"); }
        if (currentBowl == 21) { return Action.EndGame; }

        //handle 10th frame edge cases here


        if (currentBowl == 19 || currentBowl == 20)
        {


            bool spareCheck = CheckSpare(bowls[19], bowls[20]);
            if (pins == 10 || (spareCheck && !bowl21Enabled))
            {
                bowl21Enabled = true;
                return Action.Refresh;
            }

            // if bowl 21 enabled do the stuff below
            if (bowl21Enabled)
            {

                return Action.Tidy;

            }

            if (currentBowl == 20 && !bowl21Enabled) { return Action.EndGame; }


            return Action.Tidy;

        }



        //even currentBowls will always return endturn outside of the 10th frame edge cases handled above
        if (currentBowl % 2 == 0) { return Action.EndTurn; }
        //strikes always end current turn
        if (pins == 10)
        {
            //if we strike on an odd bowl, increment currentBowl an additional time. 
            if (currentBowl % 2 != 0) { currentBowl++; }
            return Action.EndTurn;
        }


        return Action.Tidy;



    }



}
