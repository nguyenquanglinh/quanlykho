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
    public class CTPhieuXuatController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<CTPhieuXuat> item = CTPhieuXuatDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] CTPhieuXuat x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            CTPhieuXuatDAO.Instance.Create(x.MaCTPX, x.MaPX, x.MaHH, x.SoLuong, x.GiaXuat);//string MaCTPX, string MaPX, string MaHH, string SoLuong, string GiaXuat
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  CTPhieuXuat x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            CTPhieuXuatDAO.Instance.Update(x.MaCTPX, x.MaPX, x.MaHH, x.SoLuong, x.GiaXuat);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaCTPX)
        {
            CTPhieuXuatDAO.Instance.Delete(MaCTPX);
            return Ok();
        }
    }
}
