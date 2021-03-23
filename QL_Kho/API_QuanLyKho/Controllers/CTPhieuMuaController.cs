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
    public class CTPhieuMuaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<CTPPhieuMua> item = CTPhieuMuaDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] CTPPhieuMua x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            CTPhieuMuaDAO.Instance.Create(x.MaCTPM, x.MaPM, x.MaHH, x.SoLuong);//(string MaCTPM, string MaPM, string MaHH, string SoLuong)
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  CTPPhieuMua x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            CTPhieuMuaDAO.Instance.Update(x.MaCTPM, x.MaPM, x.MaHH, x.SoLuong);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaCTPM)
        {
            CTPhieuMuaDAO.Instance.Delete(MaCTPM);
            return Ok();
        }

    }
}
