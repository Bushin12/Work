using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(PhotonView))]
public class Miltiplayer : MonoBehaviourPunCallbacks
{
    public static Miltiplayer Instance { get; private set; }
    private PhotonView _photonView;
    private CreateGridServer _createGrid;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        _createGrid = CreateGridServer.Instance;
        if (_photonView.IsMine)
            Instance = this;
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int[] flatMap = ArrayConverter.To1DArray(_createGrid.Map);
            bool[] flatHideCells = ArrayConverter.To1DBoolArray(_createGrid.CellActive);
            _photonView.RPC(nameof(DAVAIMap), RpcTarget.Others, flatMap, flatHideCells, _createGrid.Map.GetLength(0), _createGrid.Map.GetLength(1));
        }
    }

    public PhotonView GetPhotonView() => _photonView;

    [PunRPC]
    public void DAVAIMap(int[] flatMap, bool[] flatHideCells, int rows, int cols)
    {
        int[,] map = ArrayConverter.To2DArray(flatMap, rows, cols);
        bool[,] ActiveCell = ArrayConverter.To2DBoolArray(flatHideCells, rows, cols);
        for (int i = 0; i < flatMap.Length; i++)
        {
            print(flatMap[i]);

        }
        _createGrid.SetGrid(map, ActiveCell);
        _createGrid.SetGridPlayer();
    }
}