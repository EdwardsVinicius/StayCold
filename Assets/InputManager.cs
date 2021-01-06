// GENERATED AUTOMATICALLY FROM 'Assets/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""94155ab8-ce0d-4f12-bd2f-647f5830e874"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4630856d-325d-471c-b390-72a512063f4b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""067dd7ea-9d8b-4ae0-a80b-045c2204232f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""4da6181d-db48-4329-8e3e-841888049956"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""65af6dbb-b64e-4c30-ae13-e2c05350d14a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""184840f2-07c7-4704-9e0d-a7221d5d9cdf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e69a247-ca4f-4813-9735-e7bd6899bd3d"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""522a7fbf-cc8c-456e-b77c-d904550f1130"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2f06df59-eccb-420f-a9a5-fddbc0f35523"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""be111c8a-081e-40c4-850a-12be3c8bba59"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""73414eb5-6a33-422c-8c2e-415f1ea15c47"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""831b3a8a-a79e-4a94-a97b-f0847ea361cc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""13d7bf1d-aa6c-4ede-9191-0bfc57220439"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""45b327c1-8a1f-487d-93a9-4b1d4ecd107b"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1b316c03-7cec-458c-9e60-9a1ff3d64838"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""615750b3-9c1e-41a4-ae89-030b772fa8b7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0844ccf2-ae19-46d2-8fbe-994f157d39fa"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard;Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8c16127c-19cb-4eab-b03c-ab14755e060d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;LeftKeyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e2d1f09-50bd-4e3a-a258-7acc4b624554"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;RightKeyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9dfc9e7-24e2-458f-983d-812106aeec9b"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6adb30c9-1340-4642-9476-1436ee9d0514"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53693978-163f-4579-9561-8a930539bd18"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03ff67d2-9bd7-4085-ad01-574db55348c5"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;LeftKeyboard"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1792d63c-6946-47e5-bf56-950dafde4348"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;RightKeyboard"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80e9e1a7-fea8-4507-94c3-797f7cb3800b"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2990ccc6-9510-46d6-af2b-93b83c7571aa"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;RightKeyboard"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""577c6913-bc75-4cc3-ac5b-9ba8b76849c2"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard;LeftKeyboard"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c15ecd8-c632-4352-afa4-1ad33cfe5ca3"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb0e3232-6231-40e1-bc9a-f6c7d1dfa605"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player_1"",
            ""id"": ""d22b8035-3915-4d8a-b6ad-ce9e778260d7"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""54330c7e-a681-4c26-b756-9c5fd662dc1e"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""6a4883d0-bab3-49d1-a6e7-b90b5f3ffcd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""f0e6b354-a51d-4d59-badb-c11f75cf636d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ArrowKeys"",
                    ""id"": ""2c01d155-d425-4181-9fcb-21ef6ae31943"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ad971e92-5421-448d-8a85-54f95e1338c2"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""986887cb-e96f-4788-a3bd-80a721bddb9a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""edbe90d2-f3fe-46a3-851b-dda470a18d4e"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dbcac9e4-2daa-486f-8902-24475b05c38f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""74447b27-a3cf-4558-be45-324000017058"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c122665-b525-46c3-90e6-d4a9ec43f57f"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""RightKeyboard"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0a8adb45-6ca2-4b16-8dee-6844f6d236a7"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8eba247-10c3-4e60-ba8e-4c19f1d8f4d2"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af1e8672-55ac-4c55-8997-6f29fd5a7180"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21e39515-81f8-4101-8a49-1114ec787d06"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02b98033-918d-4b61-98c0-27c13e15af62"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ded6998-ae7c-46a7-99f3-d48701ede953"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player_2"",
            ""id"": ""b044e4aa-cdf0-420b-8c09-c8b08a71f187"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a4286085-7d0e-4731-9c2a-6ff34def9924"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""3674314b-d8dd-40a5-ba55-8b41d09a3cd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special"",
                    ""type"": ""Button"",
                    ""id"": ""1d5c6e48-4818-4e31-a792-8836ef20afa8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""9221b816-b924-4eda-8cac-871744768141"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""adba2d0d-21f3-4406-b4a4-77bc604df304"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e8967314-73c0-419f-936e-16ad93dc2333"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""121c3e50-e0e5-4d72-8ec8-314328f28492"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""69864c40-7d0e-4691-9465-e56c9b9f8e11"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9beaeff7-8b34-431d-9293-ac266e61b4c4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f194123b-0bb2-439a-870e-41097944b83b"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b43a2884-a8e4-4a7e-bd79-5be70aa15a18"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb59927e-fabb-4fdc-a252-124d9ec4aebd"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d95ae6b-acf3-41d0-b85a-d9956df178f9"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4562c170-5347-463c-afaf-a15559cd2d83"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""LeftKeyboard"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c3665b7-4042-4136-a30e-1b7d2527fb62"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2eaae071-ace6-4b6b-ab29-1ddab01b8dd7"",
                    ""path"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""LeftKeyboard"",
            ""bindingGroup"": ""LeftKeyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""RightKeyboard"",
            ""bindingGroup"": ""RightKeyboard"",
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
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<HID::MY-POWER CO.,LTD. 2In1 USB Joystick>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
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
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
        m_Gameplay_Special = m_Gameplay.FindAction("Special", throwIfNotFound: true);
        m_Gameplay_Switch = m_Gameplay.FindAction("Switch", throwIfNotFound: true);
        // Player_1
        m_Player_1 = asset.FindActionMap("Player_1", throwIfNotFound: true);
        m_Player_1_Move = m_Player_1.FindAction("Move", throwIfNotFound: true);
        m_Player_1_Attack = m_Player_1.FindAction("Attack", throwIfNotFound: true);
        m_Player_1_Special = m_Player_1.FindAction("Special", throwIfNotFound: true);
        // Player_2
        m_Player_2 = asset.FindActionMap("Player_2", throwIfNotFound: true);
        m_Player_2_Move = m_Player_2.FindAction("Move", throwIfNotFound: true);
        m_Player_2_Attack = m_Player_2.FindAction("Attack", throwIfNotFound: true);
        m_Player_2_Special = m_Player_2.FindAction("Special", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Attack;
    private readonly InputAction m_Gameplay_Special;
    private readonly InputAction m_Gameplay_Switch;
    public struct GameplayActions
    {
        private @InputManager m_Wrapper;
        public GameplayActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputAction @Special => m_Wrapper.m_Gameplay_Special;
        public InputAction @Switch => m_Wrapper.m_Gameplay_Switch;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttack;
                @Special.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial;
                @Switch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Player_1
    private readonly InputActionMap m_Player_1;
    private IPlayer_1Actions m_Player_1ActionsCallbackInterface;
    private readonly InputAction m_Player_1_Move;
    private readonly InputAction m_Player_1_Attack;
    private readonly InputAction m_Player_1_Special;
    public struct Player_1Actions
    {
        private @InputManager m_Wrapper;
        public Player_1Actions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_1_Move;
        public InputAction @Attack => m_Wrapper.m_Player_1_Attack;
        public InputAction @Special => m_Wrapper.m_Player_1_Special;
        public InputActionMap Get() { return m_Wrapper.m_Player_1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_1Actions instance)
        {
            if (m_Wrapper.m_Player_1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnAttack;
                @Special.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSpecial;
            }
            m_Wrapper.m_Player_1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
            }
        }
    }
    public Player_1Actions @Player_1 => new Player_1Actions(this);

    // Player_2
    private readonly InputActionMap m_Player_2;
    private IPlayer_2Actions m_Player_2ActionsCallbackInterface;
    private readonly InputAction m_Player_2_Move;
    private readonly InputAction m_Player_2_Attack;
    private readonly InputAction m_Player_2_Special;
    public struct Player_2Actions
    {
        private @InputManager m_Wrapper;
        public Player_2Actions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_2_Move;
        public InputAction @Attack => m_Wrapper.m_Player_2_Attack;
        public InputAction @Special => m_Wrapper.m_Player_2_Special;
        public InputActionMap Get() { return m_Wrapper.m_Player_2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_2Actions instance)
        {
            if (m_Wrapper.m_Player_2ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnMove;
                @Attack.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnAttack;
                @Special.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSpecial;
                @Special.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSpecial;
                @Special.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSpecial;
            }
            m_Wrapper.m_Player_2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Special.started += instance.OnSpecial;
                @Special.performed += instance.OnSpecial;
                @Special.canceled += instance.OnSpecial;
            }
        }
    }
    public Player_2Actions @Player_2 => new Player_2Actions(this);
    private int m_LeftKeyboardSchemeIndex = -1;
    public InputControlScheme LeftKeyboardScheme
    {
        get
        {
            if (m_LeftKeyboardSchemeIndex == -1) m_LeftKeyboardSchemeIndex = asset.FindControlSchemeIndex("LeftKeyboard");
            return asset.controlSchemes[m_LeftKeyboardSchemeIndex];
        }
    }
    private int m_RightKeyboardSchemeIndex = -1;
    public InputControlScheme RightKeyboardScheme
    {
        get
        {
            if (m_RightKeyboardSchemeIndex == -1) m_RightKeyboardSchemeIndex = asset.FindControlSchemeIndex("RightKeyboard");
            return asset.controlSchemes[m_RightKeyboardSchemeIndex];
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
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
    }
    public interface IPlayer_1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
    }
    public interface IPlayer_2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnSpecial(InputAction.CallbackContext context);
    }
}
