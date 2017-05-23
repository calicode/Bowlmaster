using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActionMaster
{
    public enum Action { Tidy, Refresh, EndGame, EndTurn };
    private int[] bowls = new int[21];
    private int currentBowl = 1;




    public Action Bowl(int pins)
    {

        if (pins < 0 || pins > 10) { throw new UnityException("ActionMaster got out of range pin count"); }
        //if (currentBowl >= 21) { return Action.EndGame; }
        //handle 10th frame edge cases here
        //        if

        if (currentBowl >= 19)
        {

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

        currentBowl++;


        return Action.Tidy;



    }



}
