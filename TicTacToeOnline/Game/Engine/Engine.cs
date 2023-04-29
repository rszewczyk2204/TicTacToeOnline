using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeOnline.Configuration.Layout;
using Windows.UI.Xaml.Controls;

namespace TicTacToeOnline.Game.Engine
{
    enum CellValue
    {
        Empty,
        X,
        O
    }

    public sealed class Engine
    {
        private bool isXLast = false;
        private ContentDialog content;
        private List<List<CellValue>> table;
        private Dictionary<string, Action> _actions;
        private List<Button> buttons = new List<Button>();

        private Engine() 
        {
            InitializeTable();

            _actions = new Dictionary<string, Action>()
            {
                { "UpperLeft", () => Compute(0, 0, isXLast ? CellValue.X : CellValue.O)},
                { "Left", () => Compute(1, 0, isXLast ? CellValue.X : CellValue.O)},
                { "LowerLeft", () => Compute(2, 0, isXLast ? CellValue.X : CellValue.O)},
                { "Upper", () => Compute(0, 1, isXLast ? CellValue.X : CellValue.O)},
                { "Middle", () => Compute(1, 1, isXLast ? CellValue.X : CellValue.O)},
                { "Lower", () => Compute(2, 1, isXLast ? CellValue.X : CellValue.O)},
                { "UpperRight", () => Compute(0, 2, isXLast ? CellValue.X : CellValue.O)},
                { "Rightt", () => Compute(1, 2, isXLast ? CellValue.X : CellValue.O)},
                { "LowerRight", () => Compute(2, 2, isXLast ? CellValue.X : CellValue.O)}
            };
        }

        public static Engine Instance { get; private set; } = new Engine();

        public void UpdateTable(Button button)
        {
            buttons.Add(button);

            if (_actions.TryGetValue(button.Name, out var action))
            {
                action();
            }
        }

        private void Compute(int rowNumber, int columnNumber, CellValue cellValue)
        {
            table[rowNumber][columnNumber] = cellValue;
            CheckAndDisplayWinner();
        }

        private void InitializeTable()
        {
            this.table = new List<List<CellValue>>();

            table.Add(new List<CellValue>() { CellValue.Empty, CellValue.Empty, CellValue.Empty});
            table.Add(new List<CellValue>() { CellValue.Empty, CellValue.Empty, CellValue.Empty});
            table.Add(new List<CellValue>() { CellValue.Empty, CellValue.Empty, CellValue.Empty});
        }

        public object ReturnXOrEllipse()
        {
            if (isXLast)
            {
                isXLast = false;
                return new EllipseControl();
            }
            isXLast = true;
            return new XControl();
        }

        private void CheckAndDisplayWinner()
        {
            if (CheckRows() || CheckColumns() || CheckLeftDiagonal() || CheckRightDiagonal())
            {
                DisplayDialog("Player won");
                return;
            }

            if (buttons.Count == 9)
            {
                DisplayDialog("Tie");
                return;
            }
        }

        private async void DisplayDialog(string title)
        {
            content = new ContentDialog
            {
                Title = title,
                PrimaryButtonText = "Play again"
            };
            ContentDialogResult result = await content.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                isXLast = false;
                ClearButtonsContent();
                ClearTable();
            }
        }

        private bool IsLineNotEmpty(List<CellValue> row)
        {
            return row.Where(value => value != CellValue.Empty).Count() == 3;
        }

        private void ClearButtonsContent()
        {
            buttons.Where(button => button != null).ToList().ForEach(button => button.Content = null);
        }

        private void ClearTable()
        {
            for(int row = 0; row < table.Count; row++)
            {
                for(int cell = 0; cell < table[row].Count; cell++)
                {
                    table[row][cell] = CellValue.Empty;
                }
            }
        }

        private void DisableButtons()
        {
            buttons.ForEach(button => button.IsEnabled = false);
        }

        private bool CheckRows()
        {
            for (int i = 0; i < table.Count; i++)
            {
                if (table[i][0] == table[i][1] && table[i][1] == table[i][2] && IsLineNotEmpty(table[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumns()
        {
            //Check for a winner in columns
            for (int col = 0; col < table[0].Count; col++)
            {
                if (table[0][col] != 0 && table[0][col] == table[1][col] && table[1][col] == table[2][col]
                    && IsLineNotEmpty(new List<CellValue>()
                    {
                        table[0][col],
                        table[1][col],
                        table[2][col]
                    }))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckLeftDiagonal()
        {
            if (table[0][0] == table[1][1] && table[1][1] == table[2][2] &&
                IsLineNotEmpty(new List<CellValue>()
                {
                    table[0][0],
                    table[1][1],
                    table[2][2]
                }))
            {

                return true;
            }

            return false;
        }

        private bool CheckRightDiagonal()
        {
            if (table[0][2] == table[1][1] && table[1][1] == table[2][0] &&
                IsLineNotEmpty(new List<CellValue>()
                {
                    table[0][2],
                    table[1][1],
                    table[2][0]
                }))
            {   
                return true;
            }

            return false;
        }
    }
}
