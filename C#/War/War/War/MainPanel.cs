using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace War
{
    /// <summary>
    /// Custom UserControl for my main menu. Just has title and an image.
    /// </summary>
    public partial class MainPanel : UserControl
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void btnNewPlayer_Click(object sender, EventArgs e)
        {
            SaveManager.StartNewGame();
            this.Visible = false;
        }
    }
}
