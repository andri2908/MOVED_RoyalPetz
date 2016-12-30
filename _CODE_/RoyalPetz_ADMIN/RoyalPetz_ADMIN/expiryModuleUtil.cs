using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace RoyalPetz_ADMIN
{
    class expiryModuleUtil
    {
        Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");

        public int getLotProductID(string productID)
        {
            int lotID = 0;
            string sqlCommand = "";

            sqlCommand = "SELECT IFNULL(PE.ID, 0) FROM PRODUCT_EXPIRY PE, MASTER_PRODUCT MP " +
                                   "WHERE PE.PRODUCT_ID = MP.PRODUCT_ID AND PE.PRODUCT_ID = '" + productID + "' AND MP.PRODUCT_ACTIVE = 1 AND MP.PRODUCT_IS_SERVICE = 0 " +
                                   "AND PE.PRODUCT_EXPIRY_DATE = (SELECT MIN(PRODUCT_EXPIRY_DATE) FROM PRODUCT_EXPIRY WHERE PRODUCT_ID = '" + productID + "' AND PRODUCT_AMOUNT > 0)";
            lotID = Convert.ToInt32(DS.executeNonQueryCommand(sqlCommand));

            return lotID;
        }

        public int[] getListOfLotProductID(string productID, double numRequested)
        {
            List<int> lotID = new List<int>();
            MySqlDataReader rdr;
            double amtRequested = 0;

            string sqlCommand = "";

            sqlCommand = "SELECT PE.ID, PE.PRODUCT_AMOUNT FROM PRODUCT_EXPIRY PE, MASTER_PRODUCT MP " +
                                   "WHERE PE.PRODUCT_AMOUNT > 0 AND PE.PRODUCT_ID = MP.PRODUCT_ID AND PE.PRODUCT_ID = '" + productID + "' AND MP.PRODUCT_ACTIVE = 1 AND MP.PRODUCT_IS_SERVICE = 0 " +
                                   "ORDER BY PE.PRODUCT_EXPIRY_DATE ASC";

            amtRequested = numRequested;
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read() && amtRequested > 0)
                    {
                        lotID.Add(rdr.GetInt32("ID"));
                        amtRequested = amtRequested - rdr.GetInt32("PRODUCT_AMOUNT");
                    }
                }
            }

            return lotID.ToArray();
        }

        public int getLotIDBasedOnExpiryDate(DateTime expiryDate, string productID)
        {
            int lotID = 0;
            string sqlCommand = "";

            string compareDate = String.Format(culture, "{0:yyyyMMdd}", expiryDate);

            sqlCommand = "SELECT IFNULL(ID, 0) FROM PRODUCT_EXPIRY WHERE PRODUCT_ID = '" + productID + "' AND DATE_FORMAT(PRODUCT_EXPIRY_DATE, '%Y%m%d') = " + compareDate;
            lotID = Convert.ToInt32(DS.getDataSingleValue(sqlCommand));

            return lotID;
        }

        public bool isExpiryDateExist(DateTime expiryDate, string productID)
        {
            bool result = false;
            string sqlCommand = "";

            string compareDate = String.Format(culture, "{0:yyyyMMdd}", expiryDate);

            sqlCommand = "SELECT EXISTS(SELECT 1 FROM PRODUCT_EXPIRY WHERE PRODUCT_ID = '" + productID + "' AND DATE_FORMAT(PRODUCT_EXPIRY_DATE, '%Y%m%d') = " + compareDate +")";
            result = Convert.ToBoolean(DS.getDataSingleValue(sqlCommand));

            return result;
        }

        public double getProductAmountFromLotID(int lotID)
        {
            double amount = 0;
            string sqlCommand = "";

            sqlCommand = "SELECT IFNULL(PRODUCT_AMOUNT, 0) FROM PRODUCT_EXPIRY WHERE ID = " + lotID;
            amount = Convert.ToDouble(DS.getDataSingleValue(sqlCommand));

            return amount;
        }
    }
}
