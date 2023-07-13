using System;

public class Evt 
{
    private event Action Action = delegate { };

    public void Invoke() {
        Action.Invoke();
    }

    public void AddListener(Action listener) {
        Action -= listener; //Only in use when listener not subscribed yet;
        Action += listener;
    }
    
    public void RemoveListener(Action listener) {
        Action -= listener;
    }
}

public class Evt<T>
{
    private event Action<T> Action = delegate { };
    
    public void Invoke(T param) {
        Action.Invoke(param);
    }
    
    public void AddListener(Action<T> listener) {
        Action -= listener; //Only in use when listener not subscribed yet;
        Action += listener;
    }
    
    public void RemoveListener(Action<T>  listener) {
        Action -= listener;
    }
}
public class Evt<T1, T2>
{
    private event Action<T1,T2> Action = delegate { };
    
    public void Invoke(T1 param0, T2 param1) {
        Action.Invoke(param0, param1);
    }
    
    public void AddListener(Action<T1, T2> listener) {
        Action -= listener; //Only in use when listener not subscribed yet;
        Action += listener;
    }
    
    public void RemoveListener(Action<T1,T2>  listener) {
        Action -= listener;
    }
}

