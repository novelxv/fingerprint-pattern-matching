public static class KMP {
    /* Function to match two patterns with KMP Algorithm */
    public static bool isAMatch(string pattern1, string pattern2){
        int M = pattern1.Length;
        // array untuk menyimpan longest prefix suffix
        int[] lpsArray = new int[M];
        int i, j = 0;
        // buat lpsArray
        makeLPSArray(pattern1, M, lpsArray);
        // iterasi sepanjang pattern2
        while (j < pattern2.Length){
            // jika karakter sama
            if (pattern1[i] == pattern2[j]){
                i++;
                j++;
            }
            // jika pattern1 sudah habis
            if (i == M){
                return true;
            }
            // jika karakter tidak sama
            else if (j < pattern2.Length && pattern1[i] != pattern2[j]){
                if (i != 0){
                    // kembali ke nilai LPS sebelumnya
                    i = lpsArray[i - 1];
                } 
                else {
                    // geser teks
                    j++;
                }
            }
        }
        return false;
    }

    /* Function to create the lpsArray */
    private static void makeLPSArray(string pattern, int M, int[] lpsArray){
        int prevLength = 0; // panjang prefix suffix sebelumnya
        lpsArray[0] = 0;
        int i = 1;
        // iterasi sepanjang pattern
        while (i < M){
            // jika karakter pada pattern cocok dengan karakter prefix
            if (pattern[i] == pattern[prevLength]){
                prevLength++;
                lpsArray[i] = prevLength;
                i++;
            } 
            else {
                if (prevLength != 0){
                    // kembali ke nilai LPS sebelumnya
                    prevLength = lpsArray[prevLength - 1];
                } 
                else {
                    lpsArray[i] = 0;
                    i++;
                }
            }
        }
    }
}