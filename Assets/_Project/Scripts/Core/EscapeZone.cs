using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EscapeZone : MonoBehaviour
{
    [SerializeField] private GameStateManager gameState;

    public event Action PlayerEscaped;

    private void Reset()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (gameState.Current != GameState.Escape)
        {
            return;
        }

        Debug.Log("Player escaped");
        PlayerEscaped?.Invoke();
    }
}