using System;
using System.Windows.Forms;
using Tetris.Mediators;
using Tetris.Properties;

namespace Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var containerView = GetContainerView();
            if (containerView == null)
                return;
            Application.Run(containerView); 
        }

        private static Form GetContainerView()
        {
            Form containerView = null;
            try
            {
                var gameMediator = new GameMediator();
                containerView = gameMediator.GetContainerView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.Title_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return containerView;
        }
    }
}
