using DemoProject.Models.Domain;

namespace DemoProject.Iservice
{
    public interface Imobileservice
    {
       public Mobile Save(Mobile oMobile);
       public Mobile GetSavedMobile();
    }
}
