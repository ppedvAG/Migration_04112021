namespace HalloEF.Model
{
    public class Kunde : Person
    {
        public string Kundennummer { get; set; }
        public virtual Mitarbeiter Mitarbeiter { get; set; }
    }

}
