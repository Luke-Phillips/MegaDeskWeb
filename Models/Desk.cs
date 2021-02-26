using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskWeb.Models
{
    /// <summary>
    /// This class represents a desk and its physical properties.
    /// It contains no methods.
    /// </summary>
    public class Desk
    {
        // Desk Dimension Constraints
        const double MAX_DEPTH = 48;
        const double MIN_DEPTH = 12;
        const double MAX_WIDTH = 96;
        const double MIN_WIDTH = 24;
        const int MIN_DRAWERS = 0;
        const int MAX_DRAWERS = 7;

        // Database Key Properties
        public int DeskId { get; set; }
        public int DesktopSurfaceMaterialId { get; set; }

        // Standard Properties
        [Range(MIN_WIDTH, MAX_WIDTH)]
        public decimal Width { get; set; }

        [Range(MIN_DEPTH, MAX_DEPTH)]
        public decimal Depth { get; set; }    
 
        [Display(Name = "Desktop Square Inches")]
        public decimal SurfaceArea { get; set; }

        [Display(Name = "Number of Drawers")]
        [Range(MIN_DRAWERS, MAX_DRAWERS)]
        public int NumberOfDrawers { get; set; }

        // Navigation Properties
        [Display(Name = "Desktop Surface Material")]
        public DesktopSurfaceMaterial DesktopSurfaceMaterial { get; set; }

        //Set the SufaceArea
        public void setSurfaceArea()
        {
            SurfaceArea = Width * Depth;
        }
    }
}
