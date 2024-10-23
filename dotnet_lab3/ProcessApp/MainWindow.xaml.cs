using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ClassLibrary;

namespace ProcessApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ProcessManager manager = new ProcessManager();
		new Dictionary<string, string> processDict = new Dictionary<string, string>();


		public MainWindow()
		{
			InitializeComponent();
			manager.KillSuccess += (sender, args) => MessageBox.Show($"Процес(и) {args.ProcessName} успішно завершено");
			manager.KillFail += (sender, args) => MessageBox.Show($"Не вдалося завершити процес(и) {args.ProcessName}:\n{args.Message}");
			manager.StartSuccess += (sender, args) => MessageBox.Show($"Процес(и) {args.ProcessName} успішно запущено");
			manager.StartFail += (sender, args) => MessageBox.Show($"Не вдалося запустити процес(и) {args.ProcessName}:\n{args.Message}");
			manager.PriorityChangeSuccess += (sender, args) => MessageBox.Show($"Для Процесу(ів) {args.ProcessName} успішно змінено пріорітет");
			manager.PriorityChangeFail += (sender, args) => MessageBox.Show($"Не вдалося змінити пріорітет для {args.ProcessName}:\n{args.Message}");

			processDict.Add("Блокнот", "notepad");
			processDict.Add("Paint", "mspaint");
			processDict.Add("Командний рядок", "cmd");
			processDict.Add("Провідник", "explorer");
			processDict.Add("Калькулятор", @"C:\Windows\System32\calc.exe");

			comboPriority.ItemsSource = new int[] { 4, 8, 13, 24 };
		}
		private void update_dataGrid(object sender, RoutedEventArgs e)
		{
			ProcessData[] array = manager.getProcessArray();
			dataGrid.ItemsSource = array;
			labelProcessCount.Content = "Кількість процесів: " + array.Length;
		}

		private void buttonKill_Click(object sender, RoutedEventArgs e)
		{
			if(dataGrid.SelectedItem != null)
			{
                ProcessData item = dataGrid.SelectedItem as ProcessData;
                if (manager.KillProcess(item.Name))
                    update_dataGrid(sender, e);
                
			}
			else MessageBox.Show("Оберіть процес");
		}

		private void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			string procName = processDict[button.Content.ToString()];
			if (button != null)
			{
				if(manager.StartProcess(procName))
					update_dataGrid(sender, e);
			}
		}

		private void buttonChangePrio_Click(object sender, RoutedEventArgs e)
		{
			if (dataGrid.SelectedItem != null)
			{
				ProcessData item = dataGrid.SelectedItem as ProcessData;
				int newPriority = int.Parse(comboPriority.Text);
				if(manager.ChangeProcessPriority(item.Name, newPriority))
					update_dataGrid(sender, e);
			}
            else MessageBox.Show("Оберіть процес");
        }
	}
}
