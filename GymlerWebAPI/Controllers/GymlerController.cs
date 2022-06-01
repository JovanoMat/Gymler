using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymlerLibrary.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace GymlerWebAPI.Controllers
{
    [ApiController]
    public class GymlerController : ControllerBase
    {
        public static gymlerjovanovicmContext context = new gymlerjovanovicmContext();


        [HttpGet("nutzer")]
        public ActionResult<List<NutzerIn>> GetAllNutzer()
        {
            var nutzerInnen = context.NutzerIn;
            if (nutzerInnen == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(nutzerInnen);

            }

        }

        [HttpGet("uebungen/{uID}")]
        public ActionResult<List<Uebung>> GetUebungenByNutzer(int uID)
        {
            var nutzerInnen = context.NutzerIn;
            var uebungen = context.Uebung;

            var nutzerByID = nutzerInnen.Where(n => n.Id == uID).FirstOrDefault();


            var ubeungenByNutzer = uebungen.SelectMany(u => u.FuehrtDurch).Where(fd => fd.IdNavigation == nutzerByID).ToList();


            Console.WriteLine($"Getting Uebungen from NutzerIn {nutzerByID.Nutzername}...");

            if (nutzerByID == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(uebungen);

            }


        }


        [HttpGet("plaene/{uID}")]
        public ActionResult<List<Trainingsplan>> GetPlaeneByNutzer(int uID)
        {
            var nutzerInnen = context.NutzerIn;
            var nutzerByID = nutzerInnen.Where(n => n.Id == uID).FirstOrDefault();


            var plaeneByNutzer = nutzerByID.Trainingsplan.ToList();


            Console.WriteLine($"Getting Plaene from NutzerIn {nutzerByID.Nutzername}...");

            if (nutzerByID == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(plaeneByNutzer);

            }


        }


        [HttpPost("pleane/{plan}/nutzer/{nutzer}")]
        public ActionResult<Trainingsplan> AddPlanToNutzer(Trainingsplan plan, NutzerIn nutzer)
        {
            if (nutzer == null || plan == null)
            { 
                return NotFound();
            }
            else
            {
                nutzer.Trainingsplan.Add(plan);
                return Ok(plan);

            }

        }

        [HttpPost("pleane/{plan}/uebung/{uebung}")]
        public ActionResult<Uebung> AddUebungToPlan(Trainingsplan plan, Uebung uebung)
        {
            if (uebung == null || plan == null)
            {
                return NotFound();
            }
            else
            {
                plan.Uebungs.Add(uebung);
                return Ok(uebung);

            }

        }




        [HttpDelete("nutzer/{uID}")]
        public ActionResult<NutzerIn> DeleteNutzerByID(int uID)
        {
            var nutzerToDelete = context.NutzerIn.Where(x => x.Id == uID).FirstOrDefault();
            
            if (nutzerToDelete == null)
            {
                return NotFound();
            
            }
            else
            {
                context.NutzerIn.Remove(nutzerToDelete);
                return Ok(nutzerToDelete);

            }

        }


        [HttpDelete("pleane/{planID}/uebung/{uebungsID}")]
        public ActionResult<Uebung> RemoveUebungFromPlan(int planID, int uebungsID)
        {
            var ubeungToDelete = context.Uebung.Where(u => u.UebungsId == uebungsID).FirstOrDefault();
            var planToDeleteFrom = context.Trainingsplan.Where(t => t.Id == planID).FirstOrDefault();

            if (ubeungToDelete == null || planToDeleteFrom == null)
            {
                return NotFound();

            }
            else
            {
                planToDeleteFrom.Uebungs.Remove(ubeungToDelete);
                return Ok(ubeungToDelete);

            }

        }


        [HttpPatch("uebung/{uebung}")]
        public ActionResult<Uebung> ChangeUebungBeschreibung(Uebung uebung, string beschreibung)
        {
            uebung.Durchfuehrungsbeschreibung = beschreibung;

            return Ok(uebung);


        }



    }

}
