using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NUnit.Framework;
[TestFixture]
public class ActionMasterTest


{
    private List<int> pinFalls;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action refresh = ActionMaster.Action.Refresh;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster am;
    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
        am = new ActionMaster();
    }

    [Test]
    public void T01Bowl4GetTidy()
    {

        Assert.AreEqual(tidy, am.Bowl(4));
    }


    [Test]
    public void T02BowlStrikeGetEndturn()
    {

        Assert.AreEqual(endTurn, am.Bowl(10));
    }

    [Test]
    public void T03BowlSpareGetEndturn()
    {
        am.Bowl(4);
        Assert.AreEqual(endTurn, am.Bowl(6));
    }

    [Test]
    public void T04CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        foreach (int roll in rolls)
        {
            am.Bowl(roll);
        }

        Assert.AreEqual(refresh, am.Bowl(10));
    }



}
