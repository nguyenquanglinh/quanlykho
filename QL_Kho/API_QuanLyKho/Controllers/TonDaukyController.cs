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
    public class TonDaukyController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<TonDauKy> item = TonDaukyDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] TonDauKy x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaHH, string MaKho, string SoLuong, string ThanhTien, string NgayCapNhat, string NgayNhap)
            TonDaukyDAO.Instance.Create(x.MaHH, x.MaKho, x.SoLuong, x.ThanhTien, x.NgayCapNhat, x.NgayNhap);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  TonDauKy x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            TonDaukyDAO.Instance.Update(x.MaHH, x.MaKho, x.SoLuong, x.ThanhTien, x.NgayCapNhat, x.NgayNhap);
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaHH, string MaKho, string NgayCapNhat)//(string MaHH, string MaKho, string NgayCapNhat)
        {
            TonDaukyDAO.Instance.Delete(MaHH, MaKho, NgayCapNhat);
            return Ok();
        }

    }
}
