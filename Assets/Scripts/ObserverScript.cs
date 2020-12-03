using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverScript : MonoBehaviour
{
    ConcreteSubject s;

    void Start()
    {
        s = new ConcreteSubject();
    }

    public void OnButton1Clicked()
    {
        s.Attach(new ConcreteObserver(s, "Button1"));
        Debug.Log("Attached a new subject to the observer: Button1");

    }

    public void OnButton2Clicked()
    {
        s.Attach(new ConcreteObserver(s, "Button2"));
        Debug.Log("Attached a new subject to the observer: Button2");

    }

    public void OnButton3Clicked()
    {
        s.Attach(new ConcreteObserver(s, "Button3"));
        Debug.Log("Attached a new subject to the observer: Button3");

    }

    public void OnButtonXClicked()
    {
        s.SubjectState = "GGWP";
        s.Notify();

    }

}

abstract class Subject
{
    private List<Observer> _observers = new List<Observer>();

    public void Attach(Observer observer)
    {
        _observers.Add(observer);

    }

    public void Detach(Observer observer)
    {
        _observers.Remove(observer);

    }

    public void Notify()
    {
        foreach (Observer o in _observers)
        {
            o.Update();

        }

    }

}

class ConcreteSubject : Subject
{
    private string _subjectState;

    public string SubjectState
    {
        get { return _subjectState; }
        set { _subjectState = value; }
    }

}

abstract class Observer
{
    public abstract void Update();

}

class ConcreteObserver : Observer
{
    private string _name;
    private string _observerState;
    private ConcreteSubject _subject;

    public ConcreteObserver(
      ConcreteSubject subject, string name)
    {
        this._subject = subject;
        this._name = name;

    }

    public override void Update()
    {
        _observerState = _subject.SubjectState;
        Debug.Log("Observer " + _name + " new state is " + _observerState);

    }

    public ConcreteSubject Subject
    {
        get { return _subject; }
        set { _subject = value; }

    }

}



