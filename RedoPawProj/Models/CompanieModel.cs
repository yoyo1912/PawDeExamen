namespace RedoPawProj.Models
{
    public class CompanieModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public string NumarTelefon { get; set; }
        public DateTime DataInfiintarii { get; set; }
        public int DomeniuActivitateId { get; set; }
        public DomeniuActivitateModel DomeniuActivitate { get; set; }
        
    }
}
