using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace OfficeLogger
{
    public class UIController : MonoBehaviour 
    {
        public LoadingScreen loadingScreen;
        public MainScreen mainScreen;
        public ProjectScreen projectScreen;
        public Button loginUIBackButton;
        public Button loginUINextButton;
        public Button registerUINextButton;

        public static UIState currentUIState;
        
        // Use this for initialization
        void Start () {
            RegisterButtons();
        }
        
        // Update is called once per frame
        void Update () {
            
        }
        private void RegisterButtons ()
        {
            loginUIBackButton.onClick.AddListener(() => {OnButtonPress (ButtonType.Back);});
            loginUINextButton.onClick.AddListener(() => {OnButtonPress (ButtonType.Next);});
        }
        private void UnRegisterButtons ()
        {
            loginUIBackButton.onClick.RemoveListener(() => {OnButtonPress (ButtonType.Back);});
            loginUINextButton.onClick.RemoveListener(() => {OnButtonPress (ButtonType.Next);});

        }

        private void OnButtonPress (ButtonType buttonType)
        {
            Debug.Log("Which type of button being pressed?? " + buttonType);
            switch (buttonType)
            {
                case ButtonType.Next:
                    ChangeUIOnNextButtonPress();
                    break;
                case ButtonType.Back:
                    ChangeUIOnBackButtonPress();
                    break;
            }
        }
        private void ChangeUIOnBackButtonPress ()
        {
            switch (currentUIState)
            {
                case UIState.None:
                    break;
                case UIState.LoginWindow:
                    break;
                case UIState.RegistrationWindow:
                    break;
            }
        }
        private void ChangeUIOnNextButtonPress ()
        {
            switch (currentUIState)
            {
                case UIState.None:
                    break;
                case UIState.LoginWindow:
                    break;
                case UIState.RegistrationWindow:
                    break;
            }
        }
        private void ChangeUIStatus (ref UIState _currentState, UIState _nextState)
        {
            _currentState = _nextState;
        }
    }
    public enum ButtonType 
    {
        Enter = 0,
        Back = 1,
        Next = 2,
        Cancel = 3
    };
    public enum UIState
    {
        None,
        LoginWindow,
        RegistrationWindow
    };
}