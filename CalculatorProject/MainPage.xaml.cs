namespace CalculatorProject
{
    public partial class MainPage : ContentPage
    {
        private double FirstNumber = 0;
        private double SecondNumber = 0;
        private string CurrentEntry = "";
        private CalcOperators CurrentOperator = CalcOperators.None;
        private double MemoryValue = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (CurrentEntry == "0")
                {
                    if (button.Text != "0")
                    {
                        CurrentEntry = button.Text;
                    }
                }
                else
                {
                    CurrentEntry += button.Text;
                }
                EntryField.Text = CurrentEntry;
            }
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentEntry))
            {
                CurrentEntry = CurrentEntry.Substring(0, CurrentEntry.Length - 1);

                if (string.IsNullOrEmpty(CurrentEntry))
                {
                    EntryField.Text = "0";
                }
                else
                {
                    EntryField.Text = CurrentEntry;
                }
            }
            else
            {
                EntryField.Text = "0";
            }
        }


        private void ClearClicked(object sender, EventArgs e)
        {
            FirstNumber = 0;
            SecondNumber = 0;
            CurrentEntry = "";
            CurrentOperator = CalcOperators.None;
            EntryField.Text = "0";
        }

        private void ClearLastClicked(object sender, EventArgs e)
        {
            CurrentEntry = "";
            EntryField.Text = "0";
        }


        private void SetOperator(CalcOperators newOperator)
        {
            if (!string.IsNullOrEmpty(CurrentEntry))
            {
                if (CurrentOperator == CalcOperators.None)
                {
                    FirstNumber = double.Parse(CurrentEntry);
                }
                else
                {
                    SecondNumber = double.Parse(CurrentEntry);
                    CalculateResult();
                }
            }

            CurrentOperator = newOperator;
            CurrentEntry = "";
        }

        private void CalculateResult()
        {
            double result = FirstNumber;

            switch (CurrentOperator)
            {
                case CalcOperators.Add:
                    result = FirstNumber + SecondNumber;
                    break;
                case CalcOperators.Sub:
                    result = FirstNumber - SecondNumber;
                    break;
                case CalcOperators.Multiply:
                    result = FirstNumber * SecondNumber;
                    break;
                case CalcOperators.Divide:
                    if (SecondNumber == 0)
                    {
                        EntryField.Text = "Invalid input";
                        return;
                    }
                    else
                    {
                        result = FirstNumber / SecondNumber;
                    }
                    break;
                default:
                    return;
            }

            FirstNumber = result;
            EntryField.Text = result.ToString();
        }

        private void DecimalClicked(object sender, EventArgs e)
        {
            if (CurrentEntry.Contains(","))
            {
                return;
            }

            if (string.IsNullOrEmpty(CurrentEntry))
            {
                CurrentEntry = "0,";
            }
            else
            {
                CurrentEntry += ",";
            }

            EntryField.Text = CurrentEntry;
        }

        private void btnMS_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentEntry))
            {
                MemoryValue = double.Parse(CurrentEntry);
            }
        }

        private void btnMR_Clicked(object sender, EventArgs e)
        {
            CurrentEntry = MemoryValue.ToString();
            EntryField.Text = CurrentEntry;
        }

        private void btnadd_Clicked(object sender, EventArgs e)
        {
            SetOperator(CalcOperators.Add);
        }

        private void btnsub_Clicked(object sender, EventArgs e)
        {
            SetOperator(CalcOperators.Sub);
        }

        private void btnmultiply_Clicked(object sender, EventArgs e)
        {
            SetOperator(CalcOperators.Multiply);
        }

        private void btndivide_Clicked(object sender, EventArgs e)
        {
            SetOperator(CalcOperators.Divide);
        }

        private void btnequal_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentEntry))
            {
                SecondNumber = double.Parse(CurrentEntry);
                CalculateResult();
                CurrentOperator = CalcOperators.None;
                CurrentEntry = FirstNumber.ToString();
            }
        }

    }

}
