// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/ManueInteractions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ManueInteractions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ManueInteractions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ManueInteractions"",
    ""maps"": [
        {
            ""name"": ""Menus"",
            ""id"": ""0526ad65-da24-48e2-97f3-4261b6725270"",
            ""actions"": [
                {
                    ""name"": ""Accept"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7d197281-7149-445f-a088-decaa5eaaa2d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0713941f-527d-4f38-abc4-06908bee56f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d76a63fe-3d75-48c2-83ff-0c037dc81652"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8b2df500-037b-4641-9140-706d782d79f4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Accept"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00d63e31-5e97-44c8-8232-2d55b80b7e77"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6d2accc-5dd3-4e76-b710-7d702e167c3f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbd7bbec-3b61-4222-9fbb-f25f3e6a68da"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
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
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<WebGLGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Menus
        m_Menus = asset.FindActionMap("Menus", throwIfNotFound: true);
        m_Menus_Accept = m_Menus.FindAction("Accept", throwIfNotFound: true);
        m_Menus_Back = m_Menus.FindAction("Back", throwIfNotFound: true);
        m_Menus_Pause = m_Menus.FindAction("Pause", throwIfNotFound: true);
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

    // Menus
    private readonly InputActionMap m_Menus;
    private IMenusActions m_MenusActionsCallbackInterface;
    private readonly InputAction m_Menus_Accept;
    private readonly InputAction m_Menus_Back;
    private readonly InputAction m_Menus_Pause;
    public struct MenusActions
    {
        private @ManueInteractions m_Wrapper;
        public MenusActions(@ManueInteractions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Accept => m_Wrapper.m_Menus_Accept;
        public InputAction @Back => m_Wrapper.m_Menus_Back;
        public InputAction @Pause => m_Wrapper.m_Menus_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Menus; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusActions set) { return set.Get(); }
        public void SetCallbacks(IMenusActions instance)
        {
            if (m_Wrapper.m_MenusActionsCallbackInterface != null)
            {
                @Accept.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnAccept;
                @Accept.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnAccept;
                @Accept.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnAccept;
                @Back.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnBack;
                @Pause.started -= m_Wrapper.m_MenusActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenusActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenusActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_MenusActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Accept.started += instance.OnAccept;
                @Accept.performed += instance.OnAccept;
                @Accept.canceled += instance.OnAccept;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MenusActions @Menus => new MenusActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
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
    public interface IMenusActions
    {
        void OnAccept(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
