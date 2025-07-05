namespace DiplomskiBackend.Model.IzdanjeEntitet
{
    public class IzdanjeDto
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
        public int BrojIzdanja { get; set; }
        public double Cena { get; set; }
    }
}
