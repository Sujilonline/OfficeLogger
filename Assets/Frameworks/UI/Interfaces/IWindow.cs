public interface IWindow
{
    void Activate ();
    void OnAfterActivate();
    void Deactivate();
    void OnBeforeDeactivate ();
}
