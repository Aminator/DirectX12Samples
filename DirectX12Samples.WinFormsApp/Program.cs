using System;
using System.Windows.Forms;
using DirectX12Samples.Engine;

namespace DirectX12Samples.WinFormsApp
{
    public class MyForm : Form
    {
        public MyForm()
        {
            Width = 1200;
            Height = 800;

            Load += MyForm_Load;
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
            Game game = new Game(new GameContextWinForms(this));
            game.Run();
        }
    }

    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyForm());
        }
    }
}
