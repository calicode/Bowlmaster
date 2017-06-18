using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NUnit.Framework;
[TestFixture]
public class ActionMasterTest

{
    // RED -> GREEN -> REFACTOR 
    private List<int> pinFalls;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action refresh = ActionMaster.Action.Refresh;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T01Bowl4GetTidy()
    {
        int[] rolls = { 4 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T02BowlStrikeGetEndturn()
    {
        int[] rolls = { 10 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));

    }

    [Test]
    public void T03BowlSpareGetEndturn()
    {

        int[] rolls = { 4, 6 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };


        Assert.AreEqual(refresh, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T05CheckGameEndsAfter10thFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };


        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T06YouTubeRollsEndInEndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T07CheckResetAtSpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };

        Assert.AreEqual(refresh, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08DarylBowl20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };

        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }


    [Test]
    public void T09BensBowl20Test()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };


        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10GameEndsAtBowl20()
    {
        {
            int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };


            Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
        }


    }
    [Test]
    public void T11NathanBowlIndexTest()
    {
        {
            int[] rolls = { 0, 10, 5, 1 };


            Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
        }


    }

    [Test]
    public void T12Dondi10thFrameTurkey()
    {
        {
            int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };


            Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
        }

    }

    [Test]
    public void T13ZeroOneGivesEndTurn()
    {
        {
            int[] rolls = { 0, 1 };


            Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
        }


    }



}
