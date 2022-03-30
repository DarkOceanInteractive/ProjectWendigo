using UnityEngine;

/// <summary>
/// State context abstract base class. A state context is responsible for
/// holding a state machine's current state and if necessary the public
/// variables needed by the different states. AStateContext provides a default
/// implementation for the different MonoBehaviour hooks, as well as a
/// SetState which can be called to change the current state.
/// </summary>
public abstract class AStateContext : MonoBehaviour
{
    private IState _state;

    protected IState State
    {
        get { return this._state; }
        set { this.SetState(value); }
    }

    /// <summary>
    /// Change the current state.
    /// </summary>
    public virtual void SetState(IState value)
    {
        if (this._state != null)
            this._state.Exit();
        this._state = value;
        value.SetContext(this);
        this._state.Enter();
    }

    protected virtual void FixedUpdate()
    {
        this.State.FixedUpdate();
    }

    protected virtual void LateUpdate()
    {
        this.State.LateUpdate();
    }

    protected virtual void Update()
    {
        this.State.Update();
    }
}
