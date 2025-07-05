using DiplomskiBackend.Model.EditorEntitet;
using DiplomskiBackend.Model.IzdanjeEntitet;
using DiplomskiBackend.Model.SekretarEntitet;
using Microsoft.AspNetCore.Components.Forms;

namespace DiplomskiBackend.Model
{
    public class Rad
    {
        public Guid Id { get; set; }
        public string Naziv {  get; set; }
        public string Autor { get; set; }

        public Izdanje Izdanje { get; set; }

        public Editor Editor { get; set; }

        public TehnickiUrednik TehnickiUrednik { get; set; }
        public Lektor Lektor { get; set; }
        public TehnickiSekretar TehnickiSekretar { get; set; }
        public TehnickiSaradnik TehnickiSaradnik { get; set; }


    }
}
