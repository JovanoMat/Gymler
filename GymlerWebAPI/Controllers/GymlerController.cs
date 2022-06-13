using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymlerLibrary.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace GymlerWebAPI.Controllers
{
    [Route ("api")]
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
            Console.WriteLine($"Getting Uebungen from NutzerIn {nutzerByID.Nutzername}...");

            if (nutzerByID == null)
            {
                return NotFound();
            
            }
            else
            {
                List<Uebung> uebungenByNutzer = nutzerInnen.SelectMany(n => n.FuehrtDurch).Select(f => f.Uebungs).ToList();
                return Ok(uebungenByNutzer);

            }






        }


        [HttpGet("plaene/{uID}")]
        public ActionResult<List<Trainingsplan>> GetPlaeneByNutzer(int uID)
        {
            var nutzerInnen = context.NutzerIn;
            var nutzerByID = nutzerInnen.Where(n => n.Id == uID).FirstOrDefault();
            
            Console.WriteLine($"Getting Plaene from NutzerIn {nutzerByID.Nutzername}...");


            if (nutzerByID == null)
            {
                return NotFound();
            }
            else
            {
                var plaeneByNutzer = nutzerByID.Trainingsplan.ToList();
                return Ok(plaeneByNutzer);

            }





        }


        [HttpPost("pleane/{plan}/nutzer/{nutzerId}")]
        public ActionResult<Trainingsplan> AddPlanToNutzer([FromBody] Trainingsplan plan, int nutzerId)
        {
            var nutzerById = context.NutzerIn.Where(n => n.Id == nutzerId).FirstOrDefault();

            if (nutzerById == null || plan == null)
            { 
                return NotFound();
            }
            else
            {
                nutzerById.Trainingsplan.Add(plan);
                return Ok(plan);

            }

        }

        [HttpPost("pleane/{plan}/uebung/{uebungId}")]
        public ActionResult<Uebung> AddUebungToPlan([FromBody] Trainingsplan plan, int uebungId)
        {
            var uebungById = context.Uebung.Where(u => u.UebungsId == uebungId).FirstOrDefault();

            if (uebungById == null || plan == null)
            {
                return NotFound();
            }
            else
            {
                plan.Uebungs.Add(uebungById);
                return Ok(uebungById);

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
        public ActionResult<Uebung> ChangeUebungBeschreibung([FromBody] Uebung uebung, string beschreibung)
        {
            uebung.Durchfuehrungsbeschreibung = beschreibung;

            return Ok(uebung);


        }



    }

}
