//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/UserInput/PlayerInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputAction : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c6751328-2857-4b9a-8d6a-a6a3fe4c24db"",
            ""actions"": [
                {
                    ""name"": ""OnAttack"",
                    ""type"": ""Button"",
                    ""id"": ""a3cc15a0-c753-4822-91d9-9b6f9748939e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""279c949d-2140-4b19-aa11-5ed246b22675"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OnInteract"",
                    ""type"": ""Button"",
                    ""id"": ""5f210e94-bd7a-47b4-aac5-8272059bfc76"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""7a9f75f9-7a6e-4651-8e82-9b29b80ea079"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OnPause"",
                    ""type"": ""Button"",
                    ""id"": ""3f3ffd1f-f1fe-4ce5-a7f1-32d39af6b102"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextItem"",
                    ""type"": ""Button"",
                    ""id"": ""878b2665-ee32-4405-bf8a-fb26148aeca6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OnUseItem"",
                    ""type"": ""Button"",
                    ""id"": ""3e5aa2cd-9731-49cc-b664-fee9fb6deb74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b17afb75-c479-45ed-89f6-ec7eca9fd7e5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""0095088d-2204-4aa6-90be-4c413b1563e3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2d355444-c1e1-45c0-8c39-08704b8154aa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d1afb693-148d-4d69-ab14-77c83e7966e6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d8b7385f-2e6a-4cbe-b3e8-a0ace7338d2e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8f24a936-a457-4875-acc2-dafbe484aa43"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3eab8c14-2882-49fd-8a1f-e8a67228b11b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebdb0bb0-01e9-4fd0-825b-c31f9dca98cd"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de4b055b-c2da-4e8d-85f2-4b63c7aa19ca"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35539d7b-8b43-4c02-afc8-1b6e4755f29f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71ca78c8-20fd-4367-a500-2b8c66ac2443"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnUseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_OnAttack = m_Player.FindAction("OnAttack", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_OnInteract = m_Player.FindAction("OnInteract", throwIfNotFound: true);
        m_Player_Throw = m_Player.FindAction("Throw", throwIfNotFound: true);
        m_Player_OnPause = m_Player.FindAction("OnPause", throwIfNotFound: true);
        m_Player_NextItem = m_Player.FindAction("NextItem", throwIfNotFound: true);
        m_Player_OnUseItem = m_Player.FindAction("OnUseItem", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_OnAttack;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_OnInteract;
    private readonly InputAction m_Player_Throw;
    private readonly InputAction m_Player_OnPause;
    private readonly InputAction m_Player_NextItem;
    private readonly InputAction m_Player_OnUseItem;
    public struct PlayerActions
    {
        private @PlayerInputAction m_Wrapper;
        public PlayerActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnAttack => m_Wrapper.m_Player_OnAttack;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @OnInteract => m_Wrapper.m_Player_OnInteract;
        public InputAction @Throw => m_Wrapper.m_Player_Throw;
        public InputAction @OnPause => m_Wrapper.m_Player_OnPause;
        public InputAction @NextItem => m_Wrapper.m_Player_NextItem;
        public InputAction @OnUseItem => m_Wrapper.m_Player_OnUseItem;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @OnAttack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnAttack;
                @OnAttack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnAttack;
                @OnAttack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnAttack;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @OnInteract.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnInteract;
                @OnInteract.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnInteract;
                @OnInteract.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnInteract;
                @Throw.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                @OnPause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnPause;
                @OnPause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnPause;
                @OnPause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnPause;
                @NextItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextItem;
                @NextItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextItem;
                @NextItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextItem;
                @OnUseItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnUseItem;
                @OnUseItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnUseItem;
                @OnUseItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnUseItem;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnAttack.started += instance.OnOnAttack;
                @OnAttack.performed += instance.OnOnAttack;
                @OnAttack.canceled += instance.OnOnAttack;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @OnInteract.started += instance.OnOnInteract;
                @OnInteract.performed += instance.OnOnInteract;
                @OnInteract.canceled += instance.OnOnInteract;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @OnPause.started += instance.OnOnPause;
                @OnPause.performed += instance.OnOnPause;
                @OnPause.canceled += instance.OnOnPause;
                @NextItem.started += instance.OnNextItem;
                @NextItem.performed += instance.OnNextItem;
                @NextItem.canceled += instance.OnNextItem;
                @OnUseItem.started += instance.OnOnUseItem;
                @OnUseItem.performed += instance.OnOnUseItem;
                @OnUseItem.canceled += instance.OnOnUseItem;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnOnAttack(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnOnInteract(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnOnPause(InputAction.CallbackContext context);
        void OnNextItem(InputAction.CallbackContext context);
        void OnOnUseItem(InputAction.CallbackContext context);
    }
}
