using Photon.Pun;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [SerializeField] private Miltiplayer _playerPrefab;

    private void Awake()
    {
        PhotonNetwork.Instantiate(_playerPrefab.gameObject.name, Vector3.zero, Quaternion.identity);    
    }
}
