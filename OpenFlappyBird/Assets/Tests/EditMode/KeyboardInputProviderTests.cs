using System;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

[TestFixture]
public class KeyboardInputProviderTests
{
    private KeyboardInputProvider inputProvider;
    private bool actionInvoked;
    
    [SetUp]
    public void Setup()
    {
        inputProvider = new KeyboardInputProvider();
        actionInvoked = false;
        // Subscribe to the event
        inputProvider.OnFlapAction += HandleFlapAction;
    }
    
    [TearDown]
    public void TearDown()
    {
        // Unsubscribe from the event
        inputProvider.OnFlapAction -= HandleFlapAction;
        inputProvider = null;
    }
    
    [Test]
    public void OnFlapAction_EventExists()
    {
        // We can't directly check if the event exists
        // Instead, we'll verify our handler is properly connected
        Assert.IsFalse(actionInvoked);
        
        // Create a method that can access the private event
        var methodInfo = typeof(KeyboardInputProvider).GetEvent("OnFlapAction");
        Assert.IsNotNull(methodInfo, "OnFlapAction event should exist");
    }
    
    private void HandleFlapAction()
    {
        actionInvoked = true;
    }
}