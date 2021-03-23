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
    public class CTPhieuNhapController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<CTPPhieuNhap> item = CTPhieuNhapDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] CTPPhieuNhap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            CTPhieuNhapDAO.Instance.Create(x.MaCTPN, x.MaPN, x.MaHH, x.SoLuong, x.GiaNhap);//(string MaCTPN, string MaPN, string MaHH, string SoLuong, string GiaNhap)
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  CTPPhieuNhap x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            CTPhieuNhapDAO.Instance.Update(x.MaCTPN, x.MaPN, x.MaHH, x.SoLuong, x.GiaNhap);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaCTPM)
        {
            CTPhieuNhapDAO.Instance.Delete(MaCTPM);
            return Ok();
        }

    }
}
