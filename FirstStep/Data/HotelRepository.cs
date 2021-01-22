using FirstStep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstStep.Data
{
    public class HotelRepository
    {
        static List<Hotel> Hotels;

        static List<Detail> Details;

        public HotelRepository()
        {
            if (Details == null)
            {
                Details = new List<Detail>()
                {
                    new Detail() { Id = 1, Beschreibung = "Gibt es eine zentralere Lage für ein Hotel als am Hauptbahnhof? Wohl kaum. Acht Buslinien, mehrere U- und S-Bahnen und unzählige Regional- und Fernbahnen laufen hier zusammen…." },
                    new Detail() { Id = 2, Beschreibung = "Der Berg ruft! Es locken gleich mehrere Berge mit schönen Wanderwegen, hohen Gipfeln und atemberaubenden Ausblicken. Hier leben Rehe, Steinböcke und Steinadler, Falken …" },
                    new Detail() { Id = 3, Beschreibung = "In der Ferienwohnung am Waldhotel verleben Sie einen ruhigen und naturnahen Urlaub.Ideal für Spaziergänge und Wanderungen mitten in einem der ältesten Wälder …"},
                    new Detail() { Id = 4, Beschreibung = "Das Hotel Mama wirbt mit seinem exklusiven Wäscheservice und den hervorragenden Mahlzeiten. Die Altersbeschränkung der Kunden (bis zum 30igsten Lebensjahr) sorgt für ein dauerhaft junges Publikum…" },
                    new Detail() { Id = 5, Beschreibung = "Das Neptun Hotel verfügt über einen der schönsten und breitesten Strände und ist ein Hotel für die ganze Familie..." }
                };
            }
            if (Hotels == null)
            {
                Hotels = new List<Hotel>()
                {
                    new Hotel() { Id = 1, Bezeichnung = "Hotel am Hauptbahnhof", Sterne = 1, RegionId = 3},
                    new Hotel() { Id = 2, Bezeichnung = "Jägerhof", Sterne = 2, RegionId = 1},
                    new Hotel() { Id = 3, Bezeichnung = "Waldhotel", Sterne = 1, RegionId = 1},
                    new Hotel() { Id = 4, Bezeichnung = "Hotel Mama", Sterne = 4, RegionId = 4},
                    new Hotel() { Id = 5, Bezeichnung = "Hotel Neptun", Sterne = 5, RegionId = 2},
                };

                foreach (Hotel h in Hotels)
                {
                    Detail detail = (from d in Details
                                     where d.Id == h.Id
                                     select d).FirstOrDefault() as Detail;
                    h.Detail = detail;
                }
            }
        }

        public List<Hotel> FindAll()
        {
            return Hotels;
        }

        public Hotel FindById(int id)
        {
            var result = from h in Hotels
                         where h.Id == id
                         select h;
            return result.FirstOrDefault();
        }

        public void Delete(int id)
        {
            var result = (from h in Hotels
                          where h.Id == id
                          select h);

            Hotels.Remove(result.FirstOrDefault());
        }

        public void Delete(Hotel hotel)
        {
            Delete(hotel.Id);
        }

        public void Save(Hotel hotel)
        {
            var result = from h in Hotels
                         where h.Id == hotel.Id
                         select h;

            Hotels.Remove(result.FirstOrDefault());
            Hotels.Add(hotel);
        }

        //if (Hotels.Contains(hotel))
        // {
        //     Hotels.Remove(hotel);
        //     Hotels.
        // }
        // Hotels.Add(hotel);


        //public object GetDetail(int id)
        //{
        //    var result = from h in Hotels
        //                  where h.Id == id
        //                  select h;

        //    return result.;
        //}
    }
}