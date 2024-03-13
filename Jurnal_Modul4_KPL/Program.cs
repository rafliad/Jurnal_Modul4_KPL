internal class Program
{
    private static void Main(string[] args)
    {
        //Table Driven
        KodeBuah.namaBuah buah1 = KodeBuah.namaBuah.Kurma;
        String OutputKodeBuah1 = KodeBuah.GetKodeBuah(buah1);
        Console.WriteLine("Buah " + buah1 + " Memiliki kode buah: " + OutputKodeBuah1);
        KodeBuah.namaBuah buah2 = KodeBuah.namaBuah.Kelapa;
        String OutputKodeBuah2 = KodeBuah.GetKodeBuah(buah2);
        Console.WriteLine("Buah " + buah2 + " Memiliki kode buah: " + OutputKodeBuah2);
        KodeBuah.namaBuah buah3 = KodeBuah.namaBuah.Durian;
        String OutputKodeBuah3 = KodeBuah.GetKodeBuah(buah3);
        Console.WriteLine("Buah " + buah3 + " Memiliki kode buah: " + OutputKodeBuah3);
    }
}

public class KodeBuah
{
    public enum namaBuah
    {
        Apel,
        Aprikot,
        Alpukat,
        Pisang,
        Paprika,
        Blackberry,
        Ceri,
        Kelapa,
        Jagung,
        Kurma,
        Durian,
        Anggur,
        Melon,
        Semangka
    }

    public static String GetKodeBuah(namaBuah inputBuah)
    {
        String[] outputKodeBuah = { "A00", "B00", "C00", "D00", "E00", "F00", "H00", "I00", "J00", "K00", "L00", "M00", "N00", "O00" };
        return outputKodeBuah[(int)inputBuah];
    }
}

