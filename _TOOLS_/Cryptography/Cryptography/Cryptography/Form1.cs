using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Management;

namespace Cryptography
{
    public partial class Form1 : Form
    {
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        public Form1()
        {
            InitializeComponent();
        }

        public static void GenKey_SaveInContainer(string ContainerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container MyKeyContainerName.
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // Display the key information to the console.
            Console.WriteLine("Key added to container: \n  {0}", rsa.ToXmlString(true));
        }

        public RSAParameters GetKeyFromContainer(string ContainerName, bool param)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            RSAParameters rsaKeyInfo;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container MyKeyContainerName.
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // Display the key information to the console.
            Console.WriteLine("Key retrieved from container : \n {0}", rsa.ToXmlString(true));

            rsaKeyInfo = rsa.ExportParameters(param);

            return rsaKeyInfo;
        }

        public static void DeleteKeyFromContainer(string ContainerName)
        {
            // Create the CspParameters object and set the key container 
            // name used to store the RSA key pair.
            CspParameters cp = new CspParameters();
            cp.KeyContainerName = ContainerName;

            // Create a new instance of RSACryptoServiceProvider that accesses
            // the key container.
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cp);

            // Delete the key entry in the container.
            rsa.PersistKeyInCsp = false;

            // Call Clear to release resources and delete the key from the container.
            rsa.Clear();

            Console.WriteLine("Key deleted.");
        }

        public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //RSA = GetKeyFromContainer("POS_CONTAINER");
                //Create a new instance of RSACryptoServiceProvider.
                //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //RSA = GetKeyFromContainer("POS_CONTAINER");
                //Create a new instance of RSACryptoServiceProvider.
                //using ()
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }

        public void readProcessorID()
        {
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }

            processorID.Text = id;

        }

        public void readHDD_ID()
        {
            string drive = "C";
            ManagementObject dsk = new ManagementObject(
                @"win32_logicaldisk.deviceid=""" + drive + @":""");
            dsk.Get();
            string volumeSerial = dsk["VolumeSerialNumber"].ToString();

            HDD_ID.Text = volumeSerial;
        }

        private void saveLicenseFile(string textToEncrypt, string filePath)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            try
            {
                byte[] dataToEncrypt = ByteConverter.GetBytes(textToEncrypt);
                byte[] encryptedData;
                RSAParameters rsaKeyInfo = GetKeyFromContainer(containerName.Text, false);

                encryptedData = RSAEncrypt(dataToEncrypt, rsaKeyInfo, false);
                File.WriteAllBytes(filePath, encryptedData);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void loadLicenseFile(string filePath)
        {
            byte[] encryptedData;
            byte[] decryptedData;
            RSAParameters rsaKeyInfo = GetKeyFromContainer(containerName.Text, true);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            try
            {
                    encryptedData = File.ReadAllBytes(filePath);
                    decryptedData = RSADecrypt(encryptedData, rsaKeyInfo, false);

                    decryptedString.Text = ByteConverter.GetString(decryptedData);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveLicenseFile(originalString.Text, saveFileDialog1.FileName);
                MessageBox.Show("DONE");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readHDD_ID();
            readProcessorID();

            originalString.Text = processorID.Text + HDD_ID.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadLicenseFile(openFileDialog1.FileName);
                MessageBox.Show("DONE");
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            GenKey_SaveInContainer(containerName.Text);
            MessageBox.Show("KEYS ARE SAVED TO CONTAINER ["+ containerName.Text + "]");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteKeyFromContainer(containerName.Text);
        }
    }
}
