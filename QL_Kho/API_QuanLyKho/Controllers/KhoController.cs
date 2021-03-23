using DataSource.DAO;
using DataSource.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_QuanLyKho.Controllers
{
    public class KhoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Kho> item = KhoDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] Kho x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaKho, string TenKho, string DiaChi)
            KhoDAO.Instance.Create(x.MaKho, x.TenKho, x.DiaChi);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  Kho x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            KhoDAO.Instance.Update(x.MaKho, x.TenKho, x.DiaChi);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaKho)
        {
            KhoDAO.Instance.Delete(MaKho);
            return Ok();
        }

    }
}