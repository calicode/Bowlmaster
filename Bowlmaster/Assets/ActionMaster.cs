using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionMaster
{
    public enum Action { Tidy, Refresh, EndGame, EndTurn };
    private int[] bowls = new int[21];
    private int currentBowl = 0;




    public Action Bowl(int pins)
    {
        currentBowl++;
        if (pins < 0 || pins > 10) { throw new UnityException("ActionMaster got out of range pin count"); }

        //handle 10th frame edge cases here

        if (currentBowl >= 19 && currentBowl < 21)
        {
            Debug.Log("in 10th frame");
            if (pins == 10)
            {
                return Action.Refresh;
            }
        }

        if (currentBowl == 21) { return Action.EndGame; }


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
