using ClassLibrary;
using Microsoft.Win32;
using System.Windows;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace EncryptionApp
{
    public partial class MainWindow : Window
    {
        string selectedFile;
        Encryptor encryptor;

        public MainWindow()
        {
            InitializeComponent();
            encryptor = new Encryptor();
            encryptor.ProgressChanged += ProgressChanged;
            encryptor.Completed += WorkCompleted;
            encryptor.ProcessFail += ProcessFail;
        }
        private void buttonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFile = openFileDialog.FileName;
                update_labelFile(sender, e);
                stackPanel.IsEnabled = true;
            }
        }

        private void buttonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if(selectedFile != "")
            {
                string password = textboxKey.Text;
                if (password != "")
                {
                    GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

                    encryptor.FileEncrypt(selectedFile, password);

                    Encryptor.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                    gch.Free();

                    selectedFile = "";
                    update_labelFile(sender, e);
                }
                else MessageBox.Show("Введіть ключ.");
            }
            else MessageBox.Show("Оберіть файл");
        }

        private void buttonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (selectedFile != "")
            {
                if (selectedFile.Substring(selectedFile.Length - 4) == ".aes")
                {
                    string password = textboxKey.Text;
                    if (password != "")
                    {

                        GCHandle gch = GCHandle.Alloc(password, GCHandleType.Pinned);

                        encryptor.FileDecrypt(selectedFile, password);

                        Encryptor.ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                        gch.Free();

                        selectedFile = "";
                        update_labelFile(sender, e);
                    }
                    else MessageBox.Show("Введіть ключ.");
                }
                else MessageBox.Show("Невірний формат файлу. Оберіть файл .aes");
            }
            else MessageBox.Show("Оберіть файл");
        }

        private void update_labelFile (object sender, RoutedEventArgs e)
        {
            if (selectedFile!="")
            {
                labelFile.Content = "Обраний файл: " + selectedFile;
            }
            else
            {
                labelFile.Content = "Файл не обраний";
            }
        }

        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progBar.Value = e.ProgressPercentage;
        }

        public void WorkCompleted(object sender, EncryptorEventArgs e)
        {
            MessageBox.Show($"Файл успішно оброблено за {e.ExecutionTime} мс. Розмір файлу: {e.FileSize} байт");
            progBar.Value = 0;
        }

        public void ProcessFail(object sender, EncryptorEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
    }
}
