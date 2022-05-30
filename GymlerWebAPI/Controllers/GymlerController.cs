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




    }

}
