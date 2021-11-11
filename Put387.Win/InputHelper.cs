using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Put387.WinUI
{
    public static class InputHelper
    {
        public static bool Validate(Control obj)
        {
            if (obj is ComboBox && int.Parse((obj as ComboBox).SelectedValue.ToString()) == 0)
            {
                return false;
            }
            else if (obj is TextBox && string.IsNullOrWhiteSpace((obj as TextBox).Text))
            {
                return false;
            }
            return true;
        }
    }
}
