using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPetz_ADMIN
{
    public static class globalConstants
    {
        // module ID to be used in the application       
        public const int TAMBAH_HAPUS_GROUP_USER = 2;
        public const int TAMBAH_HAPUS_GROUP_PELANGGAN = 3;

        public const int PENGATURAN_GRUP_AKSES = 51;
        public const int PENGATURAN_POTONGAN_HARGA = 52;
        public const int PENGATURAN_HARGA_JUAL = 53;
        public const int PENGATURAN_LIMIT_STOK = 54;
        public const int PENGATURAN_KATEGORI_PRODUK = 55;
        public const int PENGATURAN_NOMOR_RAK = 56;
        public const int CEK_DATA_MUTASI = 57;
        public const int TAMBAH_HAPUS_JURNAL_HARIAN = 58;
        public const int TAMBAH_HAPUS_USER = 59;
        public const int PERMINTAAN_MUTASI_BARANG = 60;
        public const int MUTASI_BARANG = 61;
        public const int PENERIMAAN_BARANG_DARI_MUTASI = 62;
        public const int PENERIMAAN_BARANG_DARI_PO = 63;
        public const int PURCHASE_ORDER_DARI_RO = 64;
        public const int RETUR_PEMBELIAN_KE_SUPPLIER = 65;
        public const int RETUR_PEMBELIAN_KE_PUSAT = 66;

        public const int STOK_PECAH_BARANG = 101;
        public const int PENYESUAIAN_STOK = 102;
        public const int PERMINTAAN_BARANG = 103;
        public const int REPRINT_PERMINTAAN_BARANG = 104;
        public const int PENERIMAAN_BARANG = 105;
        public const int PEMBAYARAN_HUTANG = 106;
        public const int PEMBAYARAN_PIUTANG = 107;
        public const int BROWSE_STOK_PECAH_BARANG = 108;
        public const int CHANGE_PASSWORD = 109;
        public const int LOGOUT_FORM = 110;
        public const int PRODUK_DETAIL_FORM = 111;
        public const int RETUR_PEMBELIAN = 112;
        public const int RETUR_PENJUALAN = 113;
        public const int RETUR_PENJUALAN_STOCK_ADJUSTMENT = 114;
        public const int CASHIER_MODULE = 115;
        public const int DATA_PIUTANG_MUTASI = 116;
        public const int BROWSE_PO_PENERIMAAN = 117;
        public const int BROWSE_MUTASI_PENERIMAAN = 118;

        public const int NEW_GROUP_USER = 201;
        public const int EDIT_GROUP_USER = 202;
        public const int NEW_USER = 203;
        public const int EDIT_USER = 204;
        public const int NEW_BRANCH = 205;
        public const int EDIT_BRANCH = 206;
        public const int NEW_CATEGORY = 207;
        public const int EDIT_CATEGORY = 208;
        public const int NEW_UNIT = 209;
        public const int EDIT_UNIT = 210;
        public const int NEW_CUSTOMER = 211;
        public const int EDIT_CUSTOMER = 212;
        public const int NEW_SUPPLIER = 213;
        public const int EDIT_SUPPLIER = 214;
        public const int NEW_PRODUK = 215;
        public const int EDIT_PRODUK = 216;
        public const int NEW_REQUEST_ORDER = 217;
        public const int EDIT_REQUEST_ORDER = 218;
        public const int NEW_PRODUCT_MUTATION = 219;
        public const int VIEW_PRODUCT_MUTATION = 220;
        public const int REJECT_PRODUCT_MUTATION = 221;
        public const int NEW_PURCHASE_ORDER = 222;
        public const int EDIT_PURCHASE_ORDER = 223;
        public const int PRINTOUT_PURCHASE_ORDER = 224;
        public const int NEW_RETUR_PEMBELIAN = 225;
        public const int EDIT_RETUR_PEMBELIAN = 226;
        public const int NEW_AKUN = 501;  //start from 5
        public const int EDIT_AKUN = 502;
        public const int NEW_DJ = 503;
        public const int EDIT_DJ = 504;


        // THESE CONSTANTS ARE USED TO CHECK GROUP ACCESS MODULE
        // THE VALUES MUST BE TIED TO THE VALUES INSIDE THE DATABASE TABLE

        // MAIN_MENU MANAJEMEN
        public const int MENU_MANAJEMEN_SISTEM = 1;
        public const int MENU_DATABASE = 2;
        public const int MENU_MANAJEMEN_USER = 3;
        public const int MENU_MANAJEMEN_CABANG = 4;
        public const int MENU_SINKRONISASI_INFORMASI = 5;
        public const int MENU_PENGATURAN_PRINTER = 6;
        public const int MENU_PENGATURAN_GAMBAR_LATAR = 7;

        // MAIN MENU GUDANG
        public const int MENU_GUDANG = 8;
        public const int MENU_PRODUK = 9;
        public const int MENU_TAMBAH_PRODUK = 10;
        public const int MENU_PENGATURAN_HARGA= 11;
        public const int MENU_PENGATURAN_LIMIT_STOK= 12;
        public const int MENU_PENGATURAN_KATEGORI_PRODUK = 13;
        public const int MENU_PECAH_SATUAN_PRODUK= 14;
        public const int MENU_PENGATURAN_NOMOR_RAK = 15;
        public const int MENU_KATEGORI = 16;
        public const int MENU_SATUAN = 17;
        public const int MENU_TAMBAH_SATUAN = 18;
        public const int MENU_PENGATURAN_KONVERSI = 19;
        public const int MENU_STOK_OPNAME = 20;
        public const int MENU_PENYESUAIAN_STOK = 21;
        public const int MENU_MUTASI_BARANG = 22;
        public const int MENU_TAMBAH_MUTASI_BARANG= 23;
        public const int MENU_CEK_PERMINTAAN_BARANG = 24;
        public const int MENU_PENERIMAAN_BARANG = 25;
        public const int MENU_PENERIMAAN_BARANG_DARI_MUTASI = 26;
        public const int MENU_PENERIMAAN_BARANG_DARI_PO = 27;

        // MAIN MENU PEMBELIAN
        public const int MENU_PEMBELIAN = 28;
        public const int MENU_SUPPLIER = 29;
        public const int MENU_REQUEST_ORDER = 30;
        public const int MENU_PURCHASE_ORDER = 31;
        public const int MENU_REPRINT_REQUEST_ORDER= 32;
        public const int MENU_RETUR_PEMBELIAN = 33;
        public const int MENU_RETUR_PERMINTAAN = 34;
        
        // MAIN MENU PENJUALAN
        public const int MENU_PENJUALAN = 35;
        public const int MENU_PELANGGAN = 36;
        public const int MENU_TRANSAKSI_PENJUALAN = 37;
        public const int MENU_SET_NO_FAKTUR = 38;
        public const int MENU_RETUR_PENJUALAN = 39;
        public const int MENU_RETUR_PENJUALAN_INVOICE = 40;
        public const int MENU_RETUR_PENJUALAN_STOK = 41;

        // MAIN MENU KEUANGAN
        public const int MENU_KEUANGAN = 42;
        public const int MENU_PENGATURAN_NO_AKUN = 43;
        public const int MENU_TRANSAKSI = 44;
        public const int MENU_TRANSAKSI_HARIAN = 45;
        public const int MENU_PEMBAYARAN_PIUTANG = 46;
        public const int MENU_PEMBAYARAN_PIUTANG_MUTASI = 47;
        public const int MENU_PEMBAYARAN_HUTANG_SUPPLIER = 48;
        public const int MENU_PENGATURAN_LIMIT_PAJAK = 49;

        public const int MENU_MODULE_MESSAGING = 50;

        // CONSTANTS FOR USER CHANGE LOG
        public const int CHANGE_LOG_LOGIN = 1;
        public const int CHANGE_LOG_LOGOUT = 2;
        public const int CHANGE_LOG_INSERT = 3;
        public const int CHANGE_LOG_UPDATE = 4;
        public const int CHANGE_LOG_SET_NON_ACTIVE = 5;
        public const int CHANGE_LOG_CASHIER_LOGIN = 6;
        public const int CHANGE_LOG_CASHIER_LOGOUT = 7;
        public const int CHANGE_LOG_PAYMENT_CREDIT = 8;
        public const int CHANGE_LOG_PAYMENT_DEBT = 9;


        //mode laporan
        public const int MENU_REPORT_USER = 601;

        public const int REPORT_SALES_SUMMARY = 701;
        public const int REPORT_SALES_DETAILED = 702;
        public const int REPORT_SALES_PRODUCT = 703;
        public const int REPORT_TOPSALES_byTAGS = 704;
        public const int REPORT_TOPSALES_byDATE = 705;
        public const int REPORT_TOPSALES_GLOBAL = 706;
        public const int REPORT_TOPSALES_ByMARGIN = 707;
        public const int REPORT_SALES_OMZET = 708;

        public const int REPORT_PURCHASE_SUMMARY = 710;
        public const int REPORT_PURCHASE_DETAILED = 711;
        public const int REPORT_PURCHASE_ByPRODUCT = 712;

        //XML file
        public const string AccountXML = "MasterAccount.xml";
        public const string BranchXML = "MasterBranch.xml";
        public const string CategoryXML = "MasterCategory.xml";
        public const string CustomerXML = "MasterCustomer.xml";
        public const string GroupXML = "MasterGroup.xml";
        public const string ProductXML = "MasterProduct.xml";
        public const string SupplierXML = "MasterSupplier.xml";
        public const string UnitXML = "MasterUnit.xml";
        public const string UserXML = "MasterUser.xml";
        public const string ProductCategoryXML = "ProductCategory.xml";
        public const string SalesReceiptXML = "SalesReceipt.xml";

        public const string SalesSummaryXML = "SalesSummary.xml";
        public const string SalesDetailedXML = "SalesDetailed.xml";
        public const string SalesbyProductXML = "SalesbyProduct.xml";
        public const string TopSalesGlobalXML = "TopSalesGlobal.xml";
        public const string TopSalesbyTagsXML = "TopSalesbyTags.xml";
        public const string TopSalesbyDateXML = "TopSalesbyDate.xml";
        public const string TopSalesbyMarginXML = "TopSalesbyMargin.xml";
        public const string SalesOmzetXML = "SalesOmzet.xml";
        public const string PrintBarcodeXML = "PrintBarcode.xml";
        public const string CashierLogXML = "CashierLog.xml";

        public const string PurchaseSummaryXML = "PurchaseSummary.xml";
        public const string PurchaseDetailedXML = "PurchaseDetailed.xml";
        public const string PurchasebyProductXML = "PurchasebyProduct.xml";

    }
}
