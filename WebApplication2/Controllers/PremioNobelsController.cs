using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
  
       
        public class PremioNobelsController : ApiController
        {
            private NobelEntities db = new NobelEntities();


        /// <summary>
        /// Controlador para gerir premio nobel
        /// 
        /// </summary>
        //[ResponseType(typeof(PremioNobel))]
        //public IHttpActionResult GetPremioNobel(int id)
        //{
        //    // premionobelid=9
        //    //premionobelid(organizaccao)=435
        //    if (!PremioNobelsExists(id))
        //    {
        //        return NotFound();
        //    }

        //    PremioNobelDetailsDTO premioNobel =  db.PremioNobel.Include("Categoria").Include("Laureado")
        //        .Where(p=>p.PremioNobelId == id).Select( p=> new PremioNobelDetailsDTO()
        //        { 
        //            Ano = p.Ano,
        //            Motivacao = p.Motivacao,
        //            PremioNobelId = p.PremioNobelId,
        //            Titulo = p.Titulo,
        //            Categoria = new CategoriaDTO()
        //            {
        //                CategoriaId = p.CategoriaId,
        //                Nome = p.Categoria.Nome
        //            },
        //            Individuo = p.Laureado.Select( r => new LaureadoIndividuoDTO()
        //            {
        //                DataMorte = r.LaureadoIndividuo.DataMorte,
        //                DataNascimento = r.LaureadoIndividuo.DataNascimento,
        //                LaureadoId = r.LaureadoId,
        //                Nome = r.LaureadoIndividuo.Nome,
        //                Sexo= r.LaureadoIndividuo.Sexo
        //            }).ToList(),
        //            Organizacao = p.Laureado.Where( xxx=> xxx.LaureadoTipo=="O").Select()

        //        })
        //}

        private bool PremioNobelsExists(int id)
        {
            return db.PremioNobel.Count(e => e.PremioNobelId == id) > 0;
        }

        // GET: api/PremioNobels
        public IQueryable<PremioNobelDTO> GetPremioNobel()
            {
                return db.PremioNobel.Select(p => new PremioNobelDTO()
                {
                    PremioNobelId = p.PremioNobelId,
                    Ano = p.Ano,
                    Categoria = new CategoriaDTO()
                    {
                        CategoriaId = p.CategoriaId,
                        Nome = p.Categoria.Nome
                    },
                    Titulo = p.Titulo,
                    Motivacao = p.Motivacao
                }).OrderBy(p => p.Ano);
            }

            // GET: api/PremioNobels/5
            [ResponseType(typeof(PremioNobel))]
            public IHttpActionResult GetPremioNobel(int id)
            {
                PremioNobel premioNobel = db.PremioNobel.Find(id);
                if (premioNobel == null)
                {
                    return NotFound();
                }

                return Ok(premioNobel);
            }

            //// PUT: api/PremioNobels/5
            //[ResponseType(typeof(void))]
            //public IHttpActionResult PutPremioNobel(int id, PremioNobel premioNobel)
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }

            //    if (id != premioNobel.PremioNobelId)
            //    {
            //        return BadRequest();
            //    }

            //    db.Entry(premioNobel).State = EntityState.Modified;

            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!PremioNobelExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return StatusCode(HttpStatusCode.NoContent);
            //}

            //// POST: api/PremioNobels
            //[ResponseType(typeof(PremioNobel))]
            //public IHttpActionResult PostPremioNobel(PremioNobel premioNobel)
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return BadRequest(ModelState);
            //    }

            //    db.PremioNobel.Add(premioNobel);
            //    db.SaveChanges();

            //    return CreatedAtRoute("DefaultApi", new { id = premioNobel.PremioNobelId }, premioNobel);
            //}

            //// DELETE: api/PremioNobels/5
            //[ResponseType(typeof(PremioNobel))]
            //public IHttpActionResult DeletePremioNobel(int id)
            //{
            //    PremioNobel premioNobel = db.PremioNobel.Find(id);
            //    if (premioNobel == null)
            //    {
            //        return NotFound();
            //    }

            //    db.PremioNobel.Remove(premioNobel);
            //    db.SaveChanges();

            //    return Ok(premioNobel);
            //}

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }

            private bool PremioNobelExists(int id)
            {
                return db.PremioNobel.Count(e => e.PremioNobelId == id) > 0;
            }
        }
    } 