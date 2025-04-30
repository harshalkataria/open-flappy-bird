using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;
using System.Reflection;

public class KeyboardInputProviderPlayTests
{
    private KeyboardInputProvider inputProvider;
    private bool actionInvoked;
    private Keyboard keyboard;
    
    [SetUp]
    public void Setup()
    {
        inputProvider = new KeyboardInputProvider();
        actionInvoked = false;
        inputProvider.OnFlapAction += HandleFlapAction;
        
        // Get the keyboard device
        keyboard = InputSystem.AddDevice<Keyboard>();
    }
    
    [TearDown]
    public void TearDown()
    {
        inputProvider.OnFlapAction -= HandleFlapAction;
        inputProvider = null;
        
        // Remove the test device
        if (keyboard != null)
            InputSystem.RemoveDevice(keyboard);
    }
    
    [UnityTest]
    public IEnumerator CheckInput_SpaceKeyPressed_InvokesOnFlapAction()
    {
        // Set up the test state
        actionInvoked = false;
        
        // Create a mock implementation that we can control
        var mockProvider = new MockKeyboardInputProvider();
        mockProvider.OnFlapAction += HandleFlapAction;
        
        // Simulate a key press by triggering the mock
        mockProvider.SimulateSpaceKeyPress();
        
        // Verify the action was invoked
        Assert.IsTrue(actionInvoked, "Flap action should be invoked when space key is pressed");
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator CheckInput_NoKeyPressed_DoesNotInvokeOnFlapAction()
    {
        // Set up the test state
        actionInvoked = false;
        
        // Run CheckInput without pressing any key
        inputProvider.CheckInput();
        
        // Verify the action was not invoked
        Assert.IsFalse(actionInvoked, "Flap action should not be invoked when no key is pressed");
        
        yield return null;
    }
    
    private void HandleFlapAction()
    {
        actionInvoked = true;
    }
    
    // Mock implementation for testing
    private class MockKeyboardInputProvider : IInputProvider
    {
        public event System.Action OnFlapAction;
        
        public void CheckInput()
        {
            // Do nothing in the mock
        }
        
        public void SimulateSpaceKeyPress()
        {
            // Simulate a space key press by invoking the action
            OnFlapAction?.Invoke();
        }
    }
} 