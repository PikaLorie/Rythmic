using System;

public interface AIBehaviour
{
    event Action OnBehaviourEnded;

    void Play();

    int Priority { get; }

  
    bool ShouldExecute();
}
