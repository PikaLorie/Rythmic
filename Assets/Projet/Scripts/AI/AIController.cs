using UnityEngine;


public class AIController : MonoBehaviour
{

    private AIBehaviour[] aiBehaviours;
   
    private void Awake()
    {
        aiBehaviours = GetComponentsInChildren<AIBehaviour>(); 

        foreach (AIBehaviour behaviour in aiBehaviours)
            behaviour.OnBehaviourEnded += OnBehaviourEnded;
    }

    private void Start()
    {
            PlayNextBehaviour();
       
    }
    
    private void PlayNextBehaviour()
    {
        AIBehaviour behaviour = GetNextBehaviour();

        if (behaviour == null)
        {
            Debug.LogError("AI has no behaviour to execute.", this);
        }
        else
        {
            Debug.Log("Playing " + behaviour);
            behaviour.Play();
        }
    }

    private AIBehaviour GetNextBehaviour()
    {
        AIBehaviour selectedBehaviour = null;


        foreach (AIBehaviour behaviour in aiBehaviours)
        {
            if (selectedBehaviour == null)
            {
                if (behaviour.ShouldExecute())
                    selectedBehaviour = behaviour;
            }
            else if (behaviour.ShouldExecute() && behaviour.Priority < selectedBehaviour.Priority)
            {
                selectedBehaviour = behaviour;
            }
        }

        return selectedBehaviour;
    }

    private void OnBehaviourEnded()
    {
        Debug.Log("Behaviour ended");
        PlayNextBehaviour();
    }
}
