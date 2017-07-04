using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ActionMaster
{


    public enum Action { Tidy, Refresh, EndGame, EndTurn };
    private static int[] bowls = new int[22];
    private static int currentBowl = 0;
    private static bool bowl21Enabled = false;
    static Action nextAction;

    static bool CheckSpare(int bowl1, int bowl2)
    {
        return (bowl1 + bowl2 == 10);


    }

    static void ResetState()
    {
        currentBowl = 0;
        bowls = new int[22];
        bowl21Enabled = false;

    }
    public static Action NextAction(List<int> pinFalls)
    {
        ResetState();
        Debug.Log("Actionmaster got pinfalls of" + pinFalls.Count);
        foreach (int pin in pinFalls)
        {

            nextAction = Bowl(pin);
        }

        Debug.Log("Inside Actionmaster returning nextaction of" + nextAction.ToString());
        return nextAction;
    }

    public static Action Bowl(int pins)
    {

        currentBowl++;
        bowls[currentBowl] = pins;


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
