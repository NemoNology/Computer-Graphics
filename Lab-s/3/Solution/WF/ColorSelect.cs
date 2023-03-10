using System.ComponentModel;
using System.Security.AccessControl;

namespace WF
{
    public partial class ColorSelect : Form
    {
        public delegate void ColorChanged(Color newColor);

        public static event ColorChanged? OnColorChanged;

        public ColorSelect(Color currentColor)
        {
            InitializeComponent();

            foreach (KnownColor kc in Enum.GetValues(typeof(KnownColor)))
            {
                _colors.Items.Add(Color.FromKnownColor(kc));
            }

            _colors.SelectedItem = currentColor;
        }

        private void Colors_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color chosenColor = (Color)_colors.SelectedItem;

            _outputColor.BackColor = chosenColor;

            OnColorChanged?.Invoke(chosenColor);
        }

    }
}
