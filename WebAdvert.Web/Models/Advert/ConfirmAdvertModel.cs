using WebAdvert.Web.Enum;

namespace WebAdvert.Web.Models.Advert
{
    public class ConfirmAdvertModel
    {
        public string Id { get; set; }
        public string FilePath { get; set; }
        public AdvertStatus Status { get; set; }
    }
}
