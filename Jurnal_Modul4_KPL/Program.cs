internal class Program
{
    private static void Main(string[] args)
    {
        //Table Driven
        Console.WriteLine("Table Driven KodeBuah\n");
        KodeBuah.namaBuah buah1 = KodeBuah.namaBuah.Kurma;
        String OutputKodeBuah1 = KodeBuah.GetKodeBuah(buah1);
        Console.WriteLine("Buah " + buah1 + " Memiliki kode buah: " + OutputKodeBuah1);
        KodeBuah.namaBuah buah2 = KodeBuah.namaBuah.Kelapa;
        String OutputKodeBuah2 = KodeBuah.GetKodeBuah(buah2);
        Console.WriteLine("Buah " + buah2 + " Memiliki kode buah: " + OutputKodeBuah2);
        KodeBuah.namaBuah buah3 = KodeBuah.namaBuah.Durian;
        String OutputKodeBuah3 = KodeBuah.GetKodeBuah(buah3);
        Console.WriteLine("Buah " + buah3 + " Memiliki kode buah: " + OutputKodeBuah3);

        //State-Based Construction
        Console.WriteLine("\nState-Based Construction Posisi Karakter Game\n");
        PosisiKarakterGame Karakter = new PosisiKarakterGame();
        Console.WriteLine("State anda sekarang adalah : " + Karakter.currentState);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolX);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolS);
        Karakter.ActivateTrigger(PosisiKarakterGame.Trigger.TombolW);
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

public class PosisiKarakterGame
{
    public enum stateGame
    {
        Jongkok,
        Berdiri,
        Terbang,
        Tengkurap
    }
    public enum Trigger
    {
        TombolW,
        TombolS,
        TombolX
    }
    public class Transition
    {
        public stateGame stateAwal;
        public stateGame stateAkhir;
        public Trigger trigger;
        public Transition(stateGame stateAwal, stateGame stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.trigger = trigger;
        }
    }
    Transition[] transisi =
    {
        new Transition(stateGame.Jongkok, stateGame.Berdiri, Trigger.TombolW),
        new Transition(stateGame.Jongkok, stateGame.Tengkurap, Trigger.TombolS),
        new Transition(stateGame.Tengkurap, stateGame.Jongkok, Trigger.TombolW),
        new Transition(stateGame.Berdiri, stateGame.Jongkok, Trigger.TombolS),
        new Transition(stateGame.Berdiri, stateGame.Terbang, Trigger.TombolW),
        new Transition(stateGame.Terbang, stateGame.Berdiri, Trigger.TombolS),
        new Transition(stateGame.Terbang, stateGame.Jongkok, Trigger.TombolX)
    };
    public stateGame GetNextState(stateGame stateAwal, Trigger trigger)
    {
        stateGame stateAkhir = stateAwal;
        for (int i = 0; i < transisi.Length; i++)
        {
            Transition perubahan = transisi[i];
            if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }
    public void ActivateTrigger(Trigger trigger)
    {
        if (trigger == Trigger.TombolW)
        {
            Console.WriteLine("Tombol arah atas ditekan");
        }
        else if (trigger == Trigger.TombolS)
        {
            Console.WriteLine("Tombol arah bawah ditekan");
        }
        currentState = GetNextState(currentState, trigger);
        Console.WriteLine("State anda sekarang adalah : " + currentState);
    }
    public stateGame currentState = stateGame.Berdiri;
}