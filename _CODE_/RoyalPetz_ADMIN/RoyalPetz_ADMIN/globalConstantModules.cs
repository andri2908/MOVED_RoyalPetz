using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPetz_ADMIN
{
    class globalConstantModules
    {
        // THESE CONSTANTS ARE USED TO CHECK GROUP ACCESS MODULE
        // THE VALUES MUST BE TIED TO THE VALUES INSIDE THE DATABASE TABLE
        public const int CHANGE_PASSWORD = 1;
        public const int PENGATURAN_LOKASI_DATABASE = 2;
        public const int BACKUP_RESTORE_DATABASE = 3;
        public const int TAMBAH_HAPUS_GRUP = 4;
        public const int PENGATURAN_GRUP_AKSES = 5;
        public const int TAMBAH_HAPUS_USER = 6;
        public const int PENGATURAN_ALAMAT_IP_PUSAT = 7;
        public const int TAMBAH_HAPUS_CABANG = 8;
    }
}
