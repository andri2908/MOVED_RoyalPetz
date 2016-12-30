*** menyalin nama master barang ***
xkode=''
SELECT deviasi
SCAN
xkode=deviasi.kdbarang
SELECT barang
IF SEEK(xkode)
   REPLACE deviasi.NmBarang WITH barang.diskripsi
ENDIF 
ENDSCAN 
