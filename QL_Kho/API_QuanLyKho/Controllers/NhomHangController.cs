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
    public class NhomHangController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<NhomHang> item = NhomHangDAO.Instance.GetList();
            return Ok(item);
        }

        public IHttpActionResult Post([FromBody] NhomHang x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            //(string MaNH, string TenNhomHang, string MoTa)
            NhomHangDAO.Instance.Create(x.MaNH, x.TenNhomHang, x.MoTa);
            return Ok();
        }

        public IHttpActionResult Put([FromBody]  NhomHang x)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid data");
            NhomHangDAO.Instance.Update(x.MaNH, x.TenNhomHang, x.MoTa); 
            return Ok();
        }

        public IHttpActionResult Delete([FromUri] string MaNH)
        {
            NhomHangDAO.Instance.Delete(MaNH);
            return Ok();
        }
    }
}
