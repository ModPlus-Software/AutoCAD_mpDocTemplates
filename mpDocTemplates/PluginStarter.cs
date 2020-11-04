namespace mpDocTemplates
{
    using System;
    using Autodesk.AutoCAD.ApplicationServices.Core;
    using Autodesk.AutoCAD.Runtime;

    /// <summary>
    /// Запуск функции в автокаде
    /// </summary>
    public class PluginStarter
    {
        MainWindow _mainWindow;

        [CommandMethod("ModPlus", "mpDocTemplates", CommandFlags.Modal)]
        public void StartFunction()
        {
#if !DEBUG
            ModPlusAPI.Statistic.SendCommandStarting(new ModPlusConnector());
#endif

            if (_mainWindow == null)
            {
                _mainWindow = new MainWindow();
                _mainWindow.Closed += Window_Closed;
            }

            if (_mainWindow.IsLoaded)
            {
                _mainWindow.Activate();
            }
            else
            {
                Application.ShowModalWindow(
                    Application.MainWindow.Handle, _mainWindow);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            _mainWindow = null;
        }
    }
}