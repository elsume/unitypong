using System.Collections;
using UnityEngine;
using Unity.Netcode;

public class GameManager : NetworkBehaviour
{
    [SerializeField] private NetworkObject paddleL;
    [SerializeField] private NetworkObject paddleR;
    
    void Start()
    {
        if (IsServer)
        {
            StartCoroutine(AssignOwnershipAfterSpawn());
        }
    }
    
    private IEnumerator AssignOwnershipAfterSpawn()
    {
        // Wait for network to fully initialize
        yield return new WaitForSeconds(1f);
        
        // Assign paddleL to host
        if (paddleL != null && paddleL.IsSpawned)
        {
            paddleL.ChangeOwnership(NetworkManager.ServerClientId);
            Debug.Log($"✓ PaddleL assigned to Host (ClientId {NetworkManager.ServerClientId})");
        }
        else
        {
            Debug.LogError("PaddleL not spawned!");
        }
        
        // Register callback for when client connects
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }
    
    private void OnClientConnected(ulong clientId)
    {
        if (!IsServer) return;
        
        // Skip if it's the server's own connection
        if (clientId == NetworkManager.ServerClientId) return;
        
        Debug.Log($"Client {clientId} connected, assigning paddleR...");
        
        StartCoroutine(AssignPaddleRToClient(clientId));
    }
    
    private IEnumerator AssignPaddleRToClient(ulong clientId)
    {
        yield return new WaitForSeconds(0.5f);
        
        if (paddleR != null && paddleR.IsSpawned)
        {
            paddleR.ChangeOwnership(clientId);
            Debug.Log($"✓ PaddleR assigned to Client (ClientId {clientId})");
        }
        else
        {
            Debug.LogError("PaddleR not spawned!");
        }
    }
    
}
