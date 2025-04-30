using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float flapStrength = 5f;
    
    [Header("Components")]
    private Rigidbody2D birdRigidbody;
    private IInputProvider inputProvider;
    
    private void Awake()
    {
        // Get required components
        birdRigidbody = GetComponent<Rigidbody2D>();
        
        // Use default keyboard input provider
        inputProvider = new KeyboardInputProvider();
    }
    
    private void OnEnable()
    {
        inputProvider.OnFlapAction += Flap;
    }
    
    private void OnDisable()
    {
        inputProvider.OnFlapAction -= Flap;
    }
    
    private void Update()
    {
        inputProvider.CheckInput();
    }
    
    private void Flap()
    {
        birdRigidbody.linearVelocity = Vector2.up * flapStrength;
    }
}

// Interface for input abstraction
public interface IInputProvider
{
    event System.Action OnFlapAction;
    void CheckInput();
}

// Concrete implementation for keyboard input
public class KeyboardInputProvider : IInputProvider
{
    public event System.Action OnFlapAction;
    
    public void CheckInput()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            OnFlapAction?.Invoke();
        }
    }
}
