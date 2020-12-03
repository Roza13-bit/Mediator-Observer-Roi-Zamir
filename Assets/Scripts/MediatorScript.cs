using System;
using UnityEngine;
using UnityEngine.UI;

public class MediatorScript : MonoBehaviour
{
    [SerializeField] Toggle checkbox1;
    [SerializeField] Toggle checkbox2;
    [SerializeField] Toggle checkbox3;
    [SerializeField] Toggle checkbox4;

    Mediator mediator = new ConcreteMediator();

    CheckboxComponent component1 = new CheckboxComponent("Checkbox1");
    CheckboxComponent component2 = new CheckboxComponent("Checkbox2");
    CheckboxComponent component3 = new CheckboxComponent("Checkbox3");
    CheckboxComponent component4 = new CheckboxComponent("Checkbox4");

    public void OnCheckbox1Toggled() 
    {
        if (checkbox1.isOn)
        {
            mediator.Register(component1);

        }
        else if (!checkbox1.isOn)
        {
            mediator.Unregister(component1);

        }


    }

    public void OnCheckbox2Toggled()
    {
        if (checkbox2.isOn)
        {
            mediator.Register(component2);

        }
        else if (!checkbox2.isOn)
        {
            mediator.Unregister(component2);

        }

    }

    public void OnCheckbox3Toggled()
    {
        if (checkbox3.isOn)
        {
            mediator.Register(component3);

        }
        else if (!checkbox3.isOn)
        {
            mediator.Unregister(component3);

        }

    }

    public void OnCheckbox4Toggled()
    {
        if (checkbox4.isOn)
        {
            mediator.Register(component4);

        }
        else if (!checkbox4.isOn)
        {
            mediator.Unregister(component4);

        }

    }

}

public interface Mediator
{
    void Register(BaseComponent component);
    void Unregister(BaseComponent component);

}

class ConcreteMediator : Mediator
{
    public event EventHandler<ComponentArgs> RegisterNotification = delegate { };
    public event EventHandler<ComponentArgs> UnRegisterNotification = delegate { };

    public ConcreteMediator()
    {
    }

    public void Register(BaseComponent component)
    {
        RegisterNotification(this, new ComponentArgs(component));
        RegisterNotification += component.ReceiveRegisterNotification;
        UnRegisterNotification += component.ReceiveUnRegisterNotification;
    }

    public void Unregister(BaseComponent component)
    {
        RegisterNotification -= component.ReceiveRegisterNotification;
        UnRegisterNotification -= component.ReceiveUnRegisterNotification;
        UnRegisterNotification(this, new ComponentArgs(component));
    }

}

public class ComponentArgs : EventArgs
{
    public ComponentArgs(BaseComponent component)
    {
        Component = component;
    }

    public BaseComponent Component { get; }
}

public abstract class BaseComponent
{
    private String name;

    public BaseComponent(String name)
    {
        this.name = name;

    }

    public override String ToString()
    {
        return name;

    }

    public abstract void ReceiveRegisterNotification( object sender, ComponentArgs componentArgs );

    public abstract void ReceiveUnRegisterNotification( object sender, ComponentArgs componentArgs );

}

class CheckboxComponent : BaseComponent
{
    public CheckboxComponent(string name) : base(name)
    {
    }

    public override void ReceiveRegisterNotification(
        object sender, ComponentArgs componentArgs)
    {
        Debug.Log( "Checkbox component new registered: " + componentArgs.Component + " : receiver @" + this );
        
    }

    public override void ReceiveUnRegisterNotification(
        object sender, ComponentArgs componentArgs)
    {
        Debug.Log( "Checkbox component new unregistered: " + componentArgs.Component + " : receiver @ " + this);
        
    }

}




