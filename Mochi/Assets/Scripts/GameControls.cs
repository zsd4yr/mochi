// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""GameController"",
            ""id"": ""37b63832-531b-4a55-a8c4-9797bf861fa4"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""659c01f8-8120-4fb4-b066-15ece9b5b2b7"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1b6d4cf2-6e7c-4821-baaf-7d02a468eb69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""c129dc01-e2da-472c-8903-b0c15034699c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""ad4a09c9-c248-4f8e-836c-cb5b8bef19bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit2"",
                    ""type"": ""Button"",
                    ""id"": ""a01d663e-fdf1-4d9d-811f-88fc0ea584b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quti"",
                    ""type"": ""Button"",
                    ""id"": ""5c700357-35da-4c6f-9b24-04940a72b5d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e79b6452-714e-48bb-bfec-ac82df0c0f05"",
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
                    ""id"": ""a03d4416-0baf-425c-b746-d8c3924f89b5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fdf97909-b47b-4cbb-af8e-91a26e5ed167"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""00f50219-e1ed-419a-b011-972da155914b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ff43d3fe-dbcc-4652-98ac-8d66ffa68d35"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""18455325-c48d-4332-81e7-bdb1241690e0"",
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
                    ""id"": ""9b6c311d-4420-440c-831d-7d3f607ac984"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8aa78165-99b4-4e37-befe-7252c44992d4"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fb621e5a-8665-465f-bcb3-f0aebdbeb941"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""539cbc8b-5630-434d-ac0d-8d90604822c8"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ca40a222-8a8c-4119-a962-f5e3204d2992"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c8dfd0b-393c-40df-95ca-5e6649e1b17d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95e52722-b629-4511-8efc-794f24d7d370"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35d9303a-34fd-44a5-80e2-6c0b5e2934db"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""74cafd96-571d-41fd-9ce6-f72b4f7197e7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93e1eea2-a090-445c-8af6-db55226e4353"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Quit2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb7b4003-a8a6-4fe4-9fd0-2cecbc78dbd8"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Quti"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // GameController
        m_GameController = asset.FindActionMap("GameController", throwIfNotFound: true);
        m_GameController_Movement = m_GameController.FindAction("Movement", throwIfNotFound: true);
        m_GameController_Interact = m_GameController.FindAction("Interact", throwIfNotFound: true);
        m_GameController_Quit = m_GameController.FindAction("Quit", throwIfNotFound: true);
        m_GameController_Restart = m_GameController.FindAction("Restart", throwIfNotFound: true);
        m_GameController_Quit2 = m_GameController.FindAction("Quit2", throwIfNotFound: true);
        m_GameController_Quti = m_GameController.FindAction("Quti", throwIfNotFound: true);
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

    // GameController
    private readonly InputActionMap m_GameController;
    private IGameControllerActions m_GameControllerActionsCallbackInterface;
    private readonly InputAction m_GameController_Movement;
    private readonly InputAction m_GameController_Interact;
    private readonly InputAction m_GameController_Quit;
    private readonly InputAction m_GameController_Restart;
    private readonly InputAction m_GameController_Quit2;
    private readonly InputAction m_GameController_Quti;
    public struct GameControllerActions
    {
        private @GameControls m_Wrapper;
        public GameControllerActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GameController_Movement;
        public InputAction @Interact => m_Wrapper.m_GameController_Interact;
        public InputAction @Quit => m_Wrapper.m_GameController_Quit;
        public InputAction @Restart => m_Wrapper.m_GameController_Restart;
        public InputAction @Quit2 => m_Wrapper.m_GameController_Quit2;
        public InputAction @Quti => m_Wrapper.m_GameController_Quti;
        public InputActionMap Get() { return m_Wrapper.m_GameController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControllerActions set) { return set.Get(); }
        public void SetCallbacks(IGameControllerActions instance)
        {
            if (m_Wrapper.m_GameControllerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnInteract;
                @Quit.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuit;
                @Quit.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuit;
                @Quit.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuit;
                @Restart.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnRestart;
                @Quit2.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuit2;
                @Quit2.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuit2;
                @Quit2.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuit2;
                @Quti.started -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuti;
                @Quti.performed -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuti;
                @Quti.canceled -= m_Wrapper.m_GameControllerActionsCallbackInterface.OnQuti;
            }
            m_Wrapper.m_GameControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Quit.started += instance.OnQuit;
                @Quit.performed += instance.OnQuit;
                @Quit.canceled += instance.OnQuit;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Quit2.started += instance.OnQuit2;
                @Quit2.performed += instance.OnQuit2;
                @Quit2.canceled += instance.OnQuit2;
                @Quti.started += instance.OnQuti;
                @Quti.performed += instance.OnQuti;
                @Quti.canceled += instance.OnQuti;
            }
        }
    }
    public GameControllerActions @GameController => new GameControllerActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IGameControllerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnQuit2(InputAction.CallbackContext context);
        void OnQuti(InputAction.CallbackContext context);
    }
}
