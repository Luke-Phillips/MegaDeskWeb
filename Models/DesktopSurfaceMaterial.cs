namespace MegaDeskWeb.Models
{
    /// <summary>
    /// Represents the surface material to be used on a desk
    /// </summary>
    public class DesktopSurfaceMaterial
    {      
        public int DesktopSurfaceMaterialId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}