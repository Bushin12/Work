using Photon.Pun;
using UnityEngine;

public class FillingUserServer : fillingUser
{
    [SerializeField] private PhotonView _photonView;
    private CellsGrid _cellsGrid;

    public override void Awake()
    {
        if(_photonView.IsMine)
            base.Awake();
    }

    public override void Start()
    {
        _cellsGrid = CellsGrid.Instance;
        base.Start();
    }

    public override void ChooseCell(Cell cell)
    {
        if(_photonView.IsMine)
        {
            base.ChooseCell(cell);
            _photonView.RPC(nameof(SendValueCell), RpcTarget.Others, Value, cell.X, cell.Y);
        }
    }

    [PunRPC]
    public void SendValueCell(int value, int x, int y)
    {
        Value = value;
        _currentFilling = _cellsGrid.GetCellByPosition(x, y);
        PutValue();
    }

    //public override void HOROSHO()
    //{
    //    base.HOROSHO();
    //}

    //public override void PLOXA()
    //{
    //    base.PLOXA();
    //}

    //public override void PutValue()
    //{
    //    base.PutValue();
    //}
}
