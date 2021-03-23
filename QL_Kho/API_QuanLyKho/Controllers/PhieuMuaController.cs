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
    public class PhieuMuaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<PhieuMua> item = PhieuMuaDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] PhieuMua x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaPM, string NgayLap, string MaNV, string GhiChu)
            PhieuMuaDAO.Instance.Create(x.MaPM, x.NgayLap, x.MaNV,x.GhiChu);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  PhieuMua x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            PhieuMuaDAO.Instance.Update(x.MaPM, x.NgayLap, x.MaNV, x.GhiChu);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaPM)
        {
            PhieuMuaDAO.Instance.Delete(MaPM);
            return Ok();
        }
    }
}
