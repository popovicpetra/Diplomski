namespace DiplomskiBackend.Model.IzdanjeEntitet
{
    public class DodajIzdanjeDto
    {
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public int BrojIzdanja { get; set; }
        public double Cena { get; set; }
    }
}
