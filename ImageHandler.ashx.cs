using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eProdajaServis.Data;
namespace eProdaja_Web
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int VOZILOID = Convert.ToInt32(context.Request["VOZILOID"]);
            Vozilo v = Servis.getVoziloID(VOZILOID);
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(v.SlikaThumg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

       
    }
}