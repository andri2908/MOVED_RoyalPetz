using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;
using System.Management;

namespace AlphaSoft
{
    class globalCryptographyMethod
    {
		private string processorID = "";	
		private string HDD_ID = "";
		RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        globalUtilities gUtil = new globalUtilities();
		private string containerName = "POS_CONTAINER";
		
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

            processorID = id;
        }
		
		public void readHDD_ID()
        {
            string drive = Path.GetPathRoot(Environment.SystemDirectory); //"C";
            drive = drive.Substring(0, 1);
            ManagementObject dsk = new ManagementObject(
                @"win32_logicaldisk.deviceid=""" + drive + @":""");
            dsk.Get();
            string volumeSerial = dsk["VolumeSerialNumber"].ToString();

            HDD_ID = volumeSerial;
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
		
		public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
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

        public byte[] RSADecrypt(byte[] DataToDecrypt, bool DoOAEPPadding, RSACryptoServiceProvider rsaProvider)
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

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = rsaProvider.Decrypt(DataToDecrypt, DoOAEPPadding);
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

        public bool checkVolumeLicense(string filePath, ref string storeName, ref string storeAddress)
        {
            bool result = false;
            byte[] encryptedData;
            byte[] decryptedData;
            CspParameters cspParams = null;
            RSACryptoServiceProvider rsaProvider = null;
            StreamReader privateKeyFile = null;
            string privateKeyText = "";
            string decryptedKeyword;
            string decryptedName;
            string decryptedAddress;

            // Select target CSP
            cspParams = new CspParameters();
            cspParams.ProviderType = 1; // PROV_RSA_FULL

            //cspParams.ProviderName; // CSP name
            rsaProvider = new RSACryptoServiceProvider(cspParams);

            // Read private/public key pair from file
            privateKeyFile = File.OpenText(filePath + "privateKey.xml");
            privateKeyText = privateKeyFile.ReadToEnd();

            // Import private/public key pair
            rsaProvider.FromXmlString(privateKeyText);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            try
            {
                encryptedData = File.ReadAllBytes(filePath + "license.lic");
                decryptedData = RSADecrypt(encryptedData, false, rsaProvider);

                string[] decryptedText = ByteConverter.GetString(decryptedData).Split('#');

                decryptedKeyword = decryptedText[0];
                decryptedName = decryptedText[1];
                decryptedAddress = decryptedText[2];

                if (decryptedKeyword == globalConstants.VOL_LICENSE_KEYWORD)
                {
                    //gUtil.setStoreInformationFromLicense(decryptedName, decryptedAddress);
                    storeName = decryptedName;
                    storeAddress = decryptedAddress;
                    result = true;
                }
                else
                    result = false;
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

		public bool checkLicenseFile(string filePath)
        {
            byte[] encryptedData;
            byte[] decryptedData;
            string decryptedString;
            bool result = false;
			RSAParameters rsaKeyInfo;	
            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            try
            {
                encryptedData = File.ReadAllBytes(filePath);
                rsaKeyInfo = GetKeyFromContainer(containerName, true);
				decryptedData = RSADecrypt(encryptedData, rsaKeyInfo, false);

                decryptedString = ByteConverter.GetString(decryptedData);

                readHDD_ID();
                readProcessorID();

                if (decryptedString == processorID+HDD_ID)
                    result = true;
            }
            catch(Exception e)
            {
            }
            
            return result;
        }
		
    }
}
