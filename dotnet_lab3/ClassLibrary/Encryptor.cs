using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Diagnostics;

namespace ClassLibrary
{
    public class EncryptorEventArgs : EventArgs
    {
        public long ExecutionTime { get;}
        public long FileSize { get;}
        public string Message { get;}

        public EncryptorEventArgs(long time,long fileSize)
        {
            ExecutionTime = time;
            FileSize = fileSize;
        }
        public EncryptorEventArgs(string message)
        {
            Message = message;
        }
    }
    public class Encryptor
	{
		[DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
		public static extern bool ZeroMemory(IntPtr Destination, int Length);

		public BackgroundWorker worker;
        string fileName;
        string password;
        long executionTime;


        public Encryptor()
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_WorkCompleted;
        }

		public static byte[] GenerateRandomSalt()
		{
			byte[] data = new byte[32];

			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				for (int i = 0; i < 10; i++)
				{
					rng.GetBytes(data);
				}
			}

			return data;
		}

        public void FileEncrypt(string inputFile, string password)
        {
            fileName = inputFile;
            this.password = password;
            worker.DoWork += Worker_FileEncrypt;
            worker.RunWorkerAsync(10000);
        }

        public void FileDecrypt(string inputFile, string password)
        {
            fileName = inputFile;
            this.password = password;
            worker.DoWork += Worker_FileDecrypt;
            worker.RunWorkerAsync(10000);
        }

        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        public void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChanged(sender, e);
        }

        public event EventHandler<EncryptorEventArgs> Completed;
        public void Worker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            worker.DoWork -= Worker_FileDecrypt;
            worker.DoWork -= Worker_FileEncrypt;
            FileInfo fileInfo = new FileInfo(fileName);
            Completed(sender, new EncryptorEventArgs(executionTime, fileInfo.Length));
        }

        public event EventHandler<EncryptorEventArgs> ProcessFail;
        public void Worker_FileEncrypt(object sender, DoWorkEventArgs e)
		{
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            byte[] salt = GenerateRandomSalt();
            (sender as BackgroundWorker).ReportProgress(10);

            FileStream fsCrypt = new FileStream(fileName + ".aes", FileMode.Create);

			byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            (sender as BackgroundWorker).ReportProgress(20);

            RijndaelManaged AES = new RijndaelManaged();
			AES.KeySize = 256;
			AES.BlockSize = 128;
			AES.Padding = PaddingMode.PKCS7;

			var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
			AES.Key = key.GetBytes(AES.KeySize / 8);
			AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;
            (sender as BackgroundWorker).ReportProgress(30);

            fsCrypt.Write(salt, 0, salt.Length);
            (sender as BackgroundWorker).ReportProgress(50);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

			FileStream fsIn = new FileStream(fileName, FileMode.Open);

			byte[] buffer = new byte[1048576];
			int read;
            (sender as BackgroundWorker).ReportProgress(75);
            try
			{
				while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
				{
					cs.Write(buffer, 0, read);
				}
				fsIn.Close();
                (sender as BackgroundWorker).ReportProgress(95);
            }
			catch (Exception ex)
			{
                if (ProcessFail != null)
                    ProcessFail(sender, new EncryptorEventArgs(ex.Message));
			}
			finally
			{
				cs.Close();
				fsCrypt.Close();
                fileName += ".aes";
                (sender as BackgroundWorker).ReportProgress(100);
            }
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
        }

		
		public void Worker_FileDecrypt(object sender, DoWorkEventArgs e)
		{
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
			byte[] salt = new byte[32];

			FileStream fsCrypt = new FileStream(fileName, FileMode.Open);
			fsCrypt.Read(salt, 0, salt.Length);
            (sender as BackgroundWorker).ReportProgress(25);

            RijndaelManaged AES = new RijndaelManaged();
			AES.KeySize = 256;
			AES.BlockSize = 128;
			var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
			AES.Key = key.GetBytes(AES.KeySize / 8);
			AES.IV = key.GetBytes(AES.BlockSize / 8);
			AES.Padding = PaddingMode.PKCS7;
			AES.Mode = CipherMode.CFB;
            (sender as BackgroundWorker).ReportProgress(50);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            string outputFile = fileName.Remove(fileName.Length - 4);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);
            (sender as BackgroundWorker).ReportProgress(75);
            int read;
			byte[] buffer = new byte[1048576];

			try
			{
				while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
				{
					fsOut.Write(buffer, 0, read);
				}
                (sender as BackgroundWorker).ReportProgress(90);
            }
			catch (CryptographicException ex_CryptographicException)
			{
                if (ProcessFail != null)
                    ProcessFail(sender, new EncryptorEventArgs(ex_CryptographicException.Message));
			}
			catch (Exception ex)
			{
                if (ProcessFail != null)
                    ProcessFail(sender, new EncryptorEventArgs(ex.Message));
            }

			try
			{
				cs.Close();
			}
			catch (Exception ex)
			{
                if (ProcessFail != null)
                    ProcessFail(sender, new EncryptorEventArgs(ex.Message));
            }
			finally
			{
				fsOut.Close();
				fsCrypt.Close();
                fileName = outputFile;
                (sender as BackgroundWorker).ReportProgress(100);
            }
            stopwatch.Stop();
            executionTime = stopwatch.ElapsedMilliseconds;
        }
	}
}
