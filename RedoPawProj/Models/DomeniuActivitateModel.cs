namespace RedoPawProj.Models
{
    public class DomeniuActivitateModel
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public ICollection<CompanieModel> Companii { get; set; }
    }
}
