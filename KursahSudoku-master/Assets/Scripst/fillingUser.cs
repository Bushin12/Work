using UnityEngine;
using static Cell;

public class fillingUser : MonoBehaviour
{
    public static fillingUser Global { private set; get; }
    public bool GameActive { private set; get; }  = true;
    public int Value { set; get; }
    protected Cell _currentFilling;
    private GameUi _gameUi;
    private Cell[,] _grid;
    private Timer _timer;
    private int _countError;
    private bool[,] _activeCells;

    public virtual void Awake()
    {
        Global = this;
    }

    public virtual void Start()
    {
        _gameUi = GameUi.Instance;
        //_timer = GetComponent<Timer>();
        //_timer.StartTImer();
    }

    public virtual void ChooseCell(Cell cell)
    {
        if(_currentFilling != null)
            CrossChange(_currentFilling.X, _currentFilling.Y, false);

        _currentFilling = cell;
        CrossChange(_currentFilling.X, _currentFilling.Y, true);
    }

    public virtual void PutValue()
    {
        if(_currentFilling != null)
        {
            if (_currentFilling.IsHade)
            {
                if(_currentFilling.Value == Value)
                {
                    PLOXA();
                }
                else
                {
                    HOROSHO();
                }
            }
        }
    }

    public virtual void PLOXA()
    {
        _currentFilling.WrongNumber(Value);
        _countError++;
        _gameUi.UpdateErrorText(_countError);
        if (_countError == 3)
        {
            _gameUi.GameOver();
            GameActive = false;
        }
    }

    public virtual void HOROSHO()
    {
        _currentFilling.Active();
        ChooseCell(_currentFilling);
        //PutCell.CurrentValue.Decrease();
        _activeCells[_currentFilling.X, _currentFilling.Y] = true;
        FinisdCheck();
    }

    private void FinisdCheck()
    {
        foreach (var item in _activeCells)
        {
            if(item == false)
            {
                print(item.ToString());
                return;
            }
        }
        _gameUi.Win();
        GameActive = false;
        _timer.StopTimer();
    }

    private void CrossChange(int x, int y, bool isChooise)
    {
        stateCell stateSomeValues = isChooise == true ? stateCell.Values : stateCell.NotChoose;
        stateCell line = isChooise == true ? stateCell.Choose : stateCell.NotChoose;
       
        for (int i = 0; i < 9; i++)
        {
            _grid[i, y].ChangeBackGround(line);
            _grid[x, i].ChangeBackGround(line);
        }
        if (_currentFilling.IsHade == false)
        {
            for (int i = 0; i < 9; i++)
            {
                _grid[x, y]._cellsThisValues[i].ChangeBackGround(stateSomeValues);
            }
        }
        
    }

    public void ResetGame()
    {
        _countError = 0;
        _gameUi.UpdateErrorText(_countError);
    }

    public void SetGrid(Cell[,] grid, bool[,] active)
    {
        _grid = grid;
        _activeCells = active;
    }


}
