using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BirdTests
{
    private GameObject birdObject;
    private Bird bird;
    private Rigidbody2D rigidbody;
    private MockInputProvider mockInput;
    
    [SetUp]
    public void Setup()
    {
        // Create a bird GameObject with required components
        birdObject = new GameObject("Bird");
        rigidbody = birdObject.AddComponent<Rigidbody2D>();
        bird = birdObject.AddComponent<Bird>();
        
        // Create and inject mock input provider
        mockInput = new MockInputProvider();
        
        // Use reflection to set the private field
        var field = typeof(Bird).GetField("inputProvider", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        field.SetValue(bird, mockInput);
        
        // Call OnEnable manually since we're setting up outside normal MonoBehaviour lifecycle
        var method = typeof(Bird).GetMethod("OnEnable", 
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        method.Invoke(bird, null);
    }
    
    [TearDown]
    public void TearDown()
    {
        UnityEngine.Object.Destroy(birdObject);
    }
    
    [UnityTest]
    public IEnumerator Flap_SetsUpwardVelocity()
    {
        // Set initial velocity to zero
        rigidbody.linearVelocity = Vector2.zero;
        
        // Trigger flap through mock input
        mockInput.TriggerFlap();
        
        // Wait a frame for physics to update
        yield return null;
        
        // Check if bird is moving upward
        Assert.Greater(rigidbody.linearVelocity.y, 0);
    }
    
    // Mock implementation of IInputProvider for testing
    private class MockInputProvider : IInputProvider
    {
        public event Action OnFlapAction;
        
        public void CheckInput()
        {
            // Do nothing in the mock
        }
        
        public void TriggerFlap()
        {
            OnFlapAction?.Invoke();
        }
    }
} 